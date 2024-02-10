using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;

namespace ZeroToHero.BestPractices.TinyLink.Infrastructure.Repositories
{
    public interface IVisitRepository
    {
        Task<Visit> AddVisit(Visit visit);
        Task<Visit> GetVisitByQuery(VisitQuery query);
        Task<bool> SaveChanges();
        Task<Visit> UpdateVisit(Visit visit);
    }
}
