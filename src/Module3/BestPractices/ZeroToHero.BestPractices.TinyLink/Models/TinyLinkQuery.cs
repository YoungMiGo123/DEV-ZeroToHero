using Microsoft.AspNetCore.Mvc;

namespace ZeroToHero.BestPractices.TinyLink.Models
{
    public class TinyLinkQuery
    {
        [FromQuery] 
        public string TinyLink { get; set; }
    }
}
