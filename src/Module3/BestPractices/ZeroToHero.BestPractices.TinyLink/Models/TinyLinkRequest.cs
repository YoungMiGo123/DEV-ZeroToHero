using Microsoft.AspNetCore.Mvc;

namespace ZeroToHero.BestPractices.TinyLink.Models
{
    public class TinyLinkRequest
    {
        [FromQuery]
        public string TinyLink { get; set; }

    }
}
