using Microsoft.EntityFrameworkCore;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;

namespace ZeroToHero.BestPractices.TinyLink.Infrastructure.Repositories
{
    public class TinyLinkRepository(TinyLinkDatabase _tinyLinkDatabase) : ITinyLinkRepository
    {
        public async Task<Link> AddLink(Link link)
        {
            var response = await _tinyLinkDatabase.TinyLinks.AddAsync(link);
            await SaveChanges();
            return response.Entity;
        }

        public async Task<Link> GetTinyLinkByHash(string hash)
        {
            return await _tinyLinkDatabase.TinyLinks.FirstOrDefaultAsync(x => x.Hash == hash);
        }

        public async Task<bool> SaveChanges()
        {
            var rowsAffected = await _tinyLinkDatabase.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<Link> UpdateLink(Link link)
        {
            var response = _tinyLinkDatabase.TinyLinks.Update(link);
            await SaveChanges();
            return response.Entity;
        }
    }
}
