using Microsoft.AspNetCore.Mvc;
using ZeroToHero.BestPractices.TinyLink.Infrastructure;
using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;
using ZeroToHero.BestPractices.TinyLink.Services;

namespace ZeroToHero.BestPractices.TinyLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinyLinkController(ITinyLinkService _tinyLinkService) : ControllerBase
    {
        [HttpPost]
        [Route("CreateTinyLink")]
        public async Task<IActionResult> CreateTinyLink(CreateTinyLinkRequest r)
        {
            var command = new CreateTinyLinkCommand { OriginalLink = r.OriginalLink };
            var tinyLink = await _tinyLinkService.CreateTinyLink(command);
            return Ok(tinyLink);
        }

        [HttpGet]
        [Route("QueryTinyLink")]
        public async Task<IActionResult> QueryTinyLink(TinyLinkRequest q)
        {
            var iPAddress = GetClientIpAddress(HttpContext);
            var userAgent = HttpContext.Request.Headers["User-Agent"];

            var query = new TinyLinkQuery
            {
                Device = userAgent,
                IPAddress = iPAddress,
                TinyLink = q.TinyLink
            };
            await _tinyLinkService.RecordVisit(query);

            var originalLink = await _tinyLinkService.GetOriginalLink(query);
            return Redirect(originalLink);

        }

        private string GetClientIpAddress(HttpContext context)
        {
            // Try to get the client IP address from the X-Real-IP header
            var clientIp = context.Request.Headers["X-Real-IP"].ToString();

            // If the X-Real-IP header is not present, fall back to the RemoteIpAddress property
            if (string.IsNullOrEmpty(clientIp))
            {
                clientIp = context.Connection.RemoteIpAddress.ToString();
            }

            return clientIp;
        }
    }
}
