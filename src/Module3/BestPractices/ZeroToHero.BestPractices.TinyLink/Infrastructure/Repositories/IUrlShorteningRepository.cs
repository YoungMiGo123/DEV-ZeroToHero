using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;

namespace ZeroToHero.BestPractices.TinyLink.Infrastructure.Repositories
{
    public interface IUrlShorteningRepository
    {
        Task<Link> AddLink(Link link);
        Task<Link> GetTinyLinkByHash(string hash);
        Task<bool> SaveChanges();
        Task<Link> UpdateLink(Link link);
    }
}
