using Microsoft.AspNetCore.Mvc;

namespace ZeroToHero.BestPractices.TinyLink.Models
{
    public class CreateTinyLinkCommand
    {
        [FromBody] 
        public string OriginalLink { get; set; }
    }
}
