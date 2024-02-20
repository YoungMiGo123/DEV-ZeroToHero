using System.Net;
using ZeroToHero.BestPractices.TinyLink.Infrastructure;
using ZeroToHero.BestPractices.TinyLink.Infrastructure.Repositories;
using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;
using ZeroToHero.BestPractices.TinyLink.Utilities;

namespace ZeroToHero.BestPractices.TinyLink.Services
{
    public class UrlShorteningService
    (
        IVisitRepository _visitRepository, 
        IUrlShorteningRepository _tinyLinkRepository,
        IHttpContextAccessor _httpContextAccessor
    ) : IUrlShorteningService
    {
        private int _createLinkAttempts = 0;
        private int _maxCreateLinkAttempts = 3;
        public async Task<Link> CreateTinyLink(CreateTinyLinkCommand command)
        {
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}//{_httpContextAccessor.HttpContext.Request.Host.Value}";

            var hash = HashHelper.GenerateHash(command.OriginalLink);
            var link = new Link()
            {
                OriginalUrl = command.OriginalLink,
                Hash = hash,
                ShortenedUrl = $"{baseUrl}/{hash}",
            };
            var tinyLink = await _tinyLinkRepository.GetTinyLinkByHash(hash);

            var canAttemptCreatingLink = _createLinkAttempts < _maxCreateLinkAttempts;

            if(!canAttemptCreatingLink)
            {
                throw new WebException("Failed to create tiny link");
            }

            if (tinyLink is not null && canAttemptCreatingLink)
            {
                _createLinkAttempts++;
                return await CreateTinyLink(command);
            }

            var response = await _tinyLinkRepository.AddLink(link);
            return response;
        }
        public async Task RecordVisit(TinyLinkQuery query)
        {
            var hash = query.TinyLink.Split("/").Last();

            var tinyLink = await _tinyLinkRepository.GetTinyLinkByHash(hash) ??
               throw new ArgumentException("Tiny link not found");

            var ipAddress = GetClientIpAddress(_httpContextAccessor!.HttpContext!);
            var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers.UserAgent.ToString() ?? string.Empty;

            var visit = await _visitRepository.GetVisitByQuery(new VisitQuery
            {
                LinkId = tinyLink.Id,
                IPAddress = ipAddress,
                Device = userAgent
            });

            if (visit is null)
            {
                await _visitRepository.AddVisit(new Visit
                {
                    LinkId = tinyLink.Id,
                    IPAddress = ipAddress,
                    Device = userAgent,
                    Count = 1
                });
                return;
            }

            visit.Count++;
            visit.ModifiedDateTime = DateTime.UtcNow;
            await _visitRepository.UpdateVisit(visit);
        }

        public async Task<string> GetOriginalLink(TinyLinkQuery query)
        {
            var hash = query.TinyLink.Split("/").Last();

            var tinyLink = await _tinyLinkRepository.GetTinyLinkByHash(hash) ??
               throw new ArgumentException("Tiny link not found");

            return tinyLink.OriginalUrl;
        }
        private static string GetClientIpAddress(HttpContext context)
        {
            var clientIp = context.Request.Headers["X-Real-IP"].ToString();

            if (string.IsNullOrEmpty(clientIp))
            {
                clientIp = context?.Connection?.RemoteIpAddress?.ToString() ?? string.Empty;
            }

            return clientIp;
        }
    }
}
