using Drilling.Infrastructure.Entities;

namespace Drilling.Infrastructure.Repositories
{
    public interface IHoleRepository
    {
        Task<Hole> AddAsync(Hole hole);
        Task<Hole> GetByIdAsync(Guid id);
        Task<Hole> EditAsync(Hole hole);
        Task DeleteAsync(Guid id);
        List<Hole> GetAll();
    }
}
