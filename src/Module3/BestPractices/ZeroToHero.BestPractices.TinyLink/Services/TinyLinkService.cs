using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;
using ZeroToHero.BestPractices.TinyLink.Utilities;

namespace ZeroToHero.BestPractices.TinyLink.Services
{
    public class TinyLinkService
    {
        
        private string baseUrl = "http://localhost:5000/";


        public Link CreateTinyLink(CreateTinyLinkCommand command)
        {
            var hash = HashHelper.GenerateHash(command.OriginalLink);
            var link = new Link()
            {
                OriginalUrl = command.OriginalLink,
                Hash = hash,
                ShortenedUrl = $"{baseUrl}{hash}",
            };
            return link;
        }
        public string GetOriginalLink(TinyLinkQuery query)
        {
            return "https://www.google.com";
        }
    }
}
