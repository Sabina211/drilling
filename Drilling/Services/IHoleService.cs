using Drilling.Infrastructure.Entities;
using Drilling.Models;
using System.Threading.Tasks;

namespace Drilling.Services
{
    public interface IHoleService
    {
        Task<HoleModel> AddAsync(HoleForm model);
        Task<HoleModel> EditAsync(Guid id, HoleForm model);
        Task<HoleModel> GetByIdAcync(Guid id);
        List<HoleModel> GetAll();
        Task DeleteAsync(Guid id);
    }
}
