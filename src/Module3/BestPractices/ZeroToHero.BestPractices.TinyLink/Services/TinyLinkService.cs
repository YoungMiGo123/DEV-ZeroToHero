using ZeroToHero.BestPractices.TinyLink.Infrastructure;
using ZeroToHero.BestPractices.TinyLink.Infrastructure.Repositories;
using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;
using ZeroToHero.BestPractices.TinyLink.Utilities;

namespace ZeroToHero.BestPractices.TinyLink.Services
{
    public class TinyLinkService
    (
        IVisitRepository _visitRepository, 
        ITinyLinkRepository _tinyLinkRepository
    ) : ITinyLinkService
    {

        private string baseUrl = "https://tinylink/";
        public async Task<Link> CreateTinyLink(CreateTinyLinkCommand command)
        {
            var hash = HashHelper.GenerateHash(command.OriginalLink);
            var link = new Link()
            {
                OriginalUrl = command.OriginalLink,
                Hash = hash,
                ShortenedUrl = $"{baseUrl}{hash}",
            };
            var tinyLink = await _tinyLinkRepository.GetTinyLinkByHash(hash);
            if (tinyLink is not null)
            {
                return tinyLink;
            }

            var response = await _tinyLinkRepository.AddLink(link);
            return response;
        }
        public async Task RecordVisit(TinyLinkQuery query)
        {
            var hash = query.TinyLink.Split("/").Last();

            var tinyLink = await _tinyLinkRepository.GetTinyLinkByHash(hash) ??
               throw new ArgumentException("Tiny link not found");

            var visit = await _visitRepository.GetVisitByQuery(new VisitQuery
            {
                LinkId = tinyLink.Id,
                IPAddress = query.IPAddress,
                Device = query.Device
            });

            if (visit is null)
            {
                await _visitRepository.AddVisit(new Visit
                {
                    LinkId = tinyLink.Id,
                    IPAddress = query.IPAddress,
                    Device = query.Device,
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
    }
}
