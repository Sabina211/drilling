using Drilling.Exceptions;
using Drilling.Extensions;
using Drilling.Infrastructure.Entities;
using Drilling.Infrastructure.Repositories;
using Drilling.Models;

namespace Drilling.Services
{
    public class DrillBlockPointService : IDrillBlockPointService
    {
        private readonly IDrillBlockPointRepository _drillBlockPointRepository;
        private readonly IDrillBlockRepository _drillBlockRepository;

        public DrillBlockPointService(IDrillBlockRepository drillBlockRepository, IDrillBlockPointRepository drillBlockPointRepository)
        {
            _drillBlockRepository = drillBlockRepository;
            _drillBlockPointRepository = drillBlockPointRepository;
        }

        public async Task<DrillBlockPointModel> AddAsync(DrillBlockPointForm model)
        {
            var drillBlock = await _drillBlockRepository.GetById(model.DrillBlockId);
            if (drillBlock == null) throw new EntityNotFoundException($"DrillBlock c id {model.DrillBlockId} не найден");
            var result = await _drillBlockPointRepository.AddAsync(
                new DrillBlockPoint(drillBlock, model.Sequence, model.X.ConvertToDouble(), model.Y.ConvertToDouble(), model.Z.ConvertToDouble()));
            return new DrillBlockPointModel(result.Id, result.DrillBlock, result.Sequence, result.X, result.Y, result.Z);
        }

        public async Task<DrillBlockPointModel> EditAsync(Guid id, DrillBlockPointForm model)
        {
            var drillBlock = await _drillBlockRepository.GetById(model.DrillBlockId);
            if (drillBlock == null) throw new EntityNotFoundException($"DrillBlock c id {model.DrillBlockId} не найден");
            var result = await _drillBlockPointRepository.EditAsync
                (new DrillBlockPoint(id, drillBlock, model.Sequence, model.X.ConvertToDouble(), model.Y.ConvertToDouble(), model.Z.ConvertToDouble()));
            return new DrillBlockPointModel(result.Id, result.DrillBlock, result.Sequence, result.X, result.Y, result.Z);
        }

        public async Task<DrillBlockPointModel> GetByIdAcync(Guid id)
        {
            var result = await _drillBlockPointRepository.GetByIdAsync(id);
            return new DrillBlockPointModel(result.Id, result.DrillBlock, result.Sequence, result.X, result.Y, result.Z);
        }

        public List<DrillBlockPointModel> GetAll()
        {
            var entities = _drillBlockPointRepository.GetAll();
            var result = new List<DrillBlockPointModel>();
            foreach (var entity in entities)
                result.Add(new DrillBlockPointModel(entity.Id, entity.DrillBlock, entity.Sequence, entity.X, entity.Y, entity.Z));
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _drillBlockPointRepository.DeleteAsync(id);
        }
    }
}
