using Microsoft.AspNetCore.Mvc;

namespace ZeroToHero.BestPractices.TinyLink.Models
{
    public class CreateTinyLinkRequest
    {
        [FromBody]
        public string OriginalLink { get; set; }
    }
}
