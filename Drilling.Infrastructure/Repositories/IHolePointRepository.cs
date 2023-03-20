using Drilling.Infrastructure.Entities;

namespace Drilling.Infrastructure.Repositories
{
    public interface IHolePointRepository
    {
        Task<HolePoint> AddAsync(HolePoint holePoint);
        Task<HolePoint> GetByIdAsync(Guid id);
        Task<HolePoint> EditAsync(HolePoint holePoint);
        Task DeleteAsync(Guid id);
        List<HolePoint> GetAll();
    }
}
