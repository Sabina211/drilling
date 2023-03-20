using Drilling.Exceptions;
using Drilling.Extensions;
using Drilling.Infrastructure.Entities;
using Drilling.Infrastructure.Exceptions;
using Drilling.Infrastructure.Repositories;
using Drilling.Models;
using System.Drawing;

namespace Drilling.Services
{
    public class HolePointService : IHolePointService
    {
        private readonly IHolePointRepository _holePointRepository;
        private readonly IHoleRepository _holeRepository;
        private readonly IDrillBlockPointRepository _drillBlockPointRepository;

        public HolePointService(
            IHolePointRepository holePointRepository, 
            IHoleRepository holeRepository, 
            IDrillBlockPointRepository drillBlockPointRepository)
        {
            _holePointRepository = holePointRepository;
            _holeRepository = holeRepository;
            _drillBlockPointRepository = drillBlockPointRepository;
        }

        public async Task<HolePointModel> AddAsync(HolePointForm model)
        {
            var hole = await _holeRepository.GetByIdAsync(model.HoleId);
            if (hole == null) throw new EntityNotFoundException($"Hole c id {model.HoleId} не найден");
            bool boolValue = await CheckHolePoint(model);
            if (boolValue)
            {
                var result = await _holePointRepository.AddAsync(new HolePoint(hole, model.X.ConvertToDouble(), model.Y.ConvertToDouble(), model.Z.ConvertToDouble()));
                return new HolePointModel(result.Id, result.Hole, result.X, result.Y, result.Z);
            }
            throw new DrillingException($"Координаты точки скважины [{model.X.ConvertToDouble()}; {model.Y.ConvertToDouble()}] находятся за пределами блока обуривания");
        }

        public async Task<HolePointModel> EditAsync(Guid id, HolePointForm model)
        {
            var hole = await _holeRepository.GetByIdAsync(model.HoleId);
            if (hole == null) throw new EntityNotFoundException($"Hole c id {model.HoleId} не найден");
            bool boolValue = await CheckHolePoint(model);
            if (boolValue)
            {
                var result = await _holePointRepository.EditAsync(new HolePoint(id, hole, model.X.ConvertToDouble(), model.Y.ConvertToDouble(), model.Z.ConvertToDouble()));
                return new HolePointModel(result.Id, result.Hole, result.X, result.Y, result.Z);
            }
            throw new DrillingException($"Координаты точки скважины [{model.X.ConvertToDouble()}; {model.Y.ConvertToDouble()}] находятся за пределами блока обуривания");
        }

        public async Task<HolePointModel> GetByIdAcync(Guid id)
        {
            var result = await _holePointRepository.GetByIdAsync(id);
            return new HolePointModel(result.Id, result.Hole, result.X, result.Y, result.Z);
        }

        public List<HolePointModel> GetAll()
        {
            var entities = _holePointRepository.GetAll();
            var result = new List<HolePointModel>();
            foreach (var entity in entities)
                result.Add( new HolePointModel(entity.Id, entity.Hole, entity.X, entity.Y, entity.Z));
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _holePointRepository.DeleteAsync(id);
        }

        private async Task<PointF[]> GetPolygonAsync(Guid holeId)
        {
            var blockId = (await _holeRepository.GetByIdAsync(holeId)).DrillBlock.Id;
            var points = _drillBlockPointRepository.GetAllPointsByBlockId(blockId);
            PointF[] polygon= new PointF[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                polygon[i] = new PointF((float)points[i].X, (float)points[i].Y);
            }
            return polygon;
        }

        private async Task<bool> CheckHolePoint(HolePointForm model)
        {
            var polygon = await GetPolygonAsync(model.HoleId);
            var point = new PointF((float)model.X.ConvertToDouble(), (float)model.Y.ConvertToDouble());
            var boolValue = point.IsPointInPolygon(polygon);
            return boolValue;
        }
    }
}
