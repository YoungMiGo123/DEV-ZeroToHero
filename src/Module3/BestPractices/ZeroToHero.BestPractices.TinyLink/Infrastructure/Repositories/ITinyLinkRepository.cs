using ZeroToHero.BestPractices.TinyLink.Models.Entities;

namespace ZeroToHero.BestPractices.TinyLink.Infrastructure.Repositories
{
    public interface ITinyLinkRepository
    {
        Task<Link> AddLink(Link link);
        Task<Link> GetTinyLink(string tinyLink);
    }
    public class TinyLinkRepository : ITinyLinkRepository
    {
        public Task<Link> AddLink(Link link)
        {
            throw new NotImplementedException();
        }

        public Task<Link> GetTinyLink(string tinyLink)
        {
            throw new NotImplementedException();
        }
    }
}
