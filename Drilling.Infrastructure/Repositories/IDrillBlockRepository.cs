using Drilling.Infrastructure.Entities;

namespace Drilling.Infrastructure.Repositories
{
    public interface IDrillBlockRepository
    {
        Task<DrillBlock> Add(DrillBlock drillBlock);
        Task<DrillBlock> GetById(Guid id);
        Task<DrillBlock> Edit(DrillBlock drillBlock);
        Task Delete(Guid id);
        List<DrillBlock> GetAll();
    }
}
