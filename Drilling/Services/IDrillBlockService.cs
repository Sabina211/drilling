using Drilling.Models;

namespace Drilling.Services
{
    public interface IDrillBlockService
    {
        Task<DrillBlockModel> AddAsync(DrillBlockForm model);
        Task<DrillBlockModel> EditAsync(Guid id, DrillBlockForm model);
        Task<DrillBlockModel> GetByIdAsync(Guid id);
        List<DrillBlockModel> GetAll();
        Task DeleteAsync(Guid id);
    }
}
