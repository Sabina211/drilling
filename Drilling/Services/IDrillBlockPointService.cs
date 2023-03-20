using Drilling.Models;

namespace Drilling.Services
{
    public interface IDrillBlockPointService
    {
        Task<DrillBlockPointModel> AddAsync(DrillBlockPointForm model);
        Task<DrillBlockPointModel> EditAsync(Guid id, DrillBlockPointForm model);
        Task<DrillBlockPointModel> GetByIdAcync(Guid id);
        List<DrillBlockPointModel> GetAll();
        Task DeleteAsync(Guid id);
    }
}
