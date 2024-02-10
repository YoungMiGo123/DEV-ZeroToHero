using Microsoft.AspNetCore.Mvc;
using ZeroToHero.BestPractices.TinyLink.Models;

namespace ZeroToHero.BestPractices.TinyLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinyLinkController() : ControllerBase
    {

        [HttpPost]
        [Route("CreateTinyLink")]
        public IActionResult CreateTinyLink(CreateTinyLinkCommand com)
        {
            return Ok();
        }

        [HttpGet]
        [Route("QueryTinyLink")]
        public IActionResult QueryTinyLink(TinyLinkQuery q)
        {
            return Ok();
        }
    }
}
