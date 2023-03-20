using Drilling.Infrastructure.Entities;
using Drilling.Infrastructure.Repositories;
using Drilling.Models;

namespace Drilling.Services
{
    public class DrillBlockService : IDrillBlockService
    {
        private readonly IDrillBlockRepository _drillBlockRepository;

        public DrillBlockService(IDrillBlockRepository drillBlockRepository)
        {
            _drillBlockRepository = drillBlockRepository;
        }

        public async Task<DrillBlockModel> AddAsync(DrillBlockForm model)
        {
            var result = await _drillBlockRepository.Add(new DrillBlock(model.Name));
            return new DrillBlockModel(result.Id, result.Name, result.UpdateTime);
        }

        public async Task<DrillBlockModel> EditAsync(Guid id, DrillBlockForm model)
        {
            var result = await _drillBlockRepository.Edit(new DrillBlock(id, model.Name, DateTime.Now));
            return new DrillBlockModel(result.Id, result.Name, result.UpdateTime);
        }

        public async Task<DrillBlockModel> GetByIdAsync(Guid id)
        {
            var result = await _drillBlockRepository.GetById(id);
            return new DrillBlockModel(result.Id, result.Name, result.UpdateTime);
        }

        public List<DrillBlockModel> GetAll()
        {
            var drillBlocks = _drillBlockRepository.GetAll();
            var result = new List<DrillBlockModel>();
            foreach (var drillBlock in drillBlocks)
                result.Add(new DrillBlockModel(drillBlock.Id, drillBlock.Name, drillBlock.UpdateTime));
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _drillBlockRepository.Delete(id);
        }
    }
}
