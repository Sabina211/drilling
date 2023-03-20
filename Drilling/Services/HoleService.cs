using Drilling.Exceptions;
using Drilling.Extensions;
using Drilling.Infrastructure.Entities;
using Drilling.Infrastructure.Repositories;
using Drilling.Models;

namespace Drilling.Services
{
    public class HoleService : IHoleService
    {
        private readonly IHoleRepository _holeRepository;
        private readonly IDrillBlockRepository _drillBlockRepository;

        public HoleService(IDrillBlockRepository drillBlockRepository, IHoleRepository holeRepository)
        {
            _holeRepository = holeRepository;
            _drillBlockRepository = drillBlockRepository;
        }

        public async Task<HoleModel> AddAsync(HoleForm model)
        {
            var drillBlock = await _drillBlockRepository.GetById(model.DrillBlockId);
            if (drillBlock == null) throw new EntityNotFoundException($"DrillBlock c id {model.DrillBlockId} не найден");
            var result = await _holeRepository.AddAsync(new Hole(model.Name, drillBlock, model.Depth.ConvertToDouble()));
            return new HoleModel(result.Id, result.Name, result.DrillBlock, result.Depth);
        }

        public async Task<HoleModel> EditAsync(Guid id, HoleForm model)
        {
            var drillBlock = await _drillBlockRepository.GetById(model.DrillBlockId);
            if (drillBlock == null) throw new EntityNotFoundException($"DrillBlock c id {model.DrillBlockId} не найден");
            var result = await _holeRepository.EditAsync(new Hole(id, model.Name, drillBlock, model.Depth.ConvertToDouble()));
            return new HoleModel(result.Id, result.Name, result.DrillBlock, result.Depth);
        }

        public async Task<HoleModel> GetByIdAcync(Guid id)
        {
            var result = await _holeRepository.GetByIdAsync(id);
            return new HoleModel(result.Id, result.Name, result.DrillBlock, result.Depth);
        }

        public List<HoleModel> GetAll()
        {
            var entities = _holeRepository.GetAll();
            var result = new List<HoleModel>();
            foreach (var entity in entities)
                result.Add(new HoleModel(entity.Id, entity.Name, entity.DrillBlock, entity.Depth));
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _holeRepository.DeleteAsync(id);
        }
    }
}
