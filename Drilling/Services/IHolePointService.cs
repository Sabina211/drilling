using Drilling.Models;

namespace Drilling.Services
{
    public interface IHolePointService
    {
        Task<HolePointModel> AddAsync(HolePointForm model);
        Task<HolePointModel> EditAsync(Guid id, HolePointForm model);
        Task<HolePointModel> GetByIdAcync(Guid id);
        List<HolePointModel> GetAll();
        Task DeleteAsync(Guid id);
    }
}
