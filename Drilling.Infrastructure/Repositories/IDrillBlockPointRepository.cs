using Drilling.Infrastructure.Entities;

namespace Drilling.Infrastructure.Repositories
{
    public interface IDrillBlockPointRepository
    {
        Task<DrillBlockPoint> AddAsync(DrillBlockPoint drillBlockPoint);
        Task<DrillBlockPoint> GetByIdAsync(Guid id);
        List<DrillBlockPoint> GetAllPointsByBlockId(Guid blockId);
        Task<DrillBlockPoint> EditAsync(DrillBlockPoint drillBlockPoint);
        Task DeleteAsync(Guid id);
        List<DrillBlockPoint> GetAll();
    }
}
