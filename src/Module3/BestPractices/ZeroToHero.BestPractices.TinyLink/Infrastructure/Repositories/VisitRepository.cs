using Microsoft.EntityFrameworkCore;
using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;

namespace ZeroToHero.BestPractices.TinyLink.Infrastructure.Repositories
{
    public class VisitRepository(TinyLinkDatabase _tinyLinkDatabase) : IVisitRepository
    {
        public async Task<Visit> AddVisit(Visit visit)
        {
            var response = _tinyLinkDatabase.Visits.Add(visit);
            await SaveChanges();
            return response.Entity;
        }

        public Task<Visit> GetVisitByQuery(VisitQuery query)
        {
           return _tinyLinkDatabase.Visits.FirstOrDefaultAsync(x => x.LinkId == query.LinkId && x.IPAddress == query.IPAddress && x.Device == query.Device);
        }

        public async Task<bool> SaveChanges()
        {
            var rowsAffected = await _tinyLinkDatabase.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<Visit> UpdateVisit(Visit link)
        {
            var response = _tinyLinkDatabase.Visits.Update(link);   
            await SaveChanges();
            return response.Entity;
        }
    }
}
