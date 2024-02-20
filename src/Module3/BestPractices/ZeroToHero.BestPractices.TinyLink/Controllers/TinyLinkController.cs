using Microsoft.AspNetCore.Mvc;
using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Services;

namespace ZeroToHero.BestPractices.TinyLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinyLinkController(IUrlShorteningService _tinyLinkService) : ControllerBase
    {
        [HttpPost]
        [Route("CreateTinyLink")]
        public async Task<IActionResult> CreateTinyLink(CreateTinyLinkCommand command)
        {
            if(!Uri.TryCreate(command.OriginalLink, UriKind.Absolute, out _))
            {
                return BadRequest("The specified URL is invalid.");
            }

            var tinyLink = await _tinyLinkService.CreateTinyLink(command);
            return Ok(tinyLink);
        }
    }
}
