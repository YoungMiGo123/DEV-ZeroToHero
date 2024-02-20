using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Services;

namespace ZeroToHero.BestPractices.TinyLink.Controllers
{

    [ApiController]
    public class RedirectController(IUrlShorteningService tinyLinkService) : ControllerBase
    {
        [HttpGet]
        [Route("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var query = new TinyLinkQuery { TinyLink = code };

            var originalLink = await tinyLinkService.GetOriginalLink(query);

            if (string.IsNullOrEmpty(originalLink))
            {
                return NotFound();
            }

            await tinyLinkService.RecordVisit(query);

            return Redirect(originalLink);
        }
    }
}
