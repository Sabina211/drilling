using Drilling.Exceptions;
using Drilling.Infrastructure.Entities;
using Drilling.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Drilling.Infrastructure.Repositories
{
    public class DrillBlockPointRepository : IDrillBlockPointRepository
    {
        private readonly DrillingContext _context;

        public DrillBlockPointRepository(DrillingContext context)
        {
            _context = context;
        }

        public async Task<DrillBlockPoint> AddAsync(DrillBlockPoint drillBlockPoint)
        {
            CheckSequence(drillBlockPoint);
            await _context.DrillBlockPoints.AddAsync(drillBlockPoint);
            await _context.SaveChangesAsync();
            return await _context.DrillBlockPoints.FirstOrDefaultAsync(x => x.Id == drillBlockPoint.Id);
        }


        public async Task<DrillBlockPoint> GetByIdAsync(Guid id)
        {
            var result = await _context.DrillBlockPoints.Include(x => x.DrillBlock).FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) throw new EntityNotFoundException($"DrillBlockPoint с id = {id} не найден");
            return result;
        }

        public List<DrillBlockPoint> GetAllPointsByBlockId(Guid blockId)
        {
            var result = _context.DrillBlockPoints.Where(x=>x.DrillBlock.Id==blockId).ToList();
            if (!result.Any()) throw new EntityNotFoundException($"Точки для {blockId} не найдены");
            return result;
        }

        public async Task<DrillBlockPoint> EditAsync(DrillBlockPoint drillBlockPoint)
        {
            CheckSequence(drillBlockPoint);
            var entity = await _context.DrillBlockPoints.FirstOrDefaultAsync(x => x.Id == drillBlockPoint.Id);
            if (entity == null) throw new EntityNotFoundException($"DrillBlockPoint с id = {drillBlockPoint.Id} не найден");
            _context.DrillBlockPoints.Attach(entity);
            entity.Sequence = drillBlockPoint.Sequence;
            entity.DrillBlock = drillBlockPoint.DrillBlock;
            entity.X = drillBlockPoint.X;
            entity.Y = drillBlockPoint.Y;
            entity.Z = drillBlockPoint.Z;

            await _context.SaveChangesAsync();
            return await _context.DrillBlockPoints.FirstOrDefaultAsync(x => x.Id == drillBlockPoint.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.DrillBlockPoints.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) throw new EntityNotFoundException($"DrillBlockPoint с id = {id} не найден");
            _context.DrillBlockPoints.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public List<DrillBlockPoint> GetAll()
        {
            var result = _context.DrillBlockPoints.Include(x => x.DrillBlock).ToList();
            return result;
        }

        private void CheckSequence(DrillBlockPoint drillBlockPoint)
        {
            //в описании задания было указано, что точки добавляются последовательно, поэтому добавила эту проверку
            var sequenceIsExist = GetAllPointsByBlockId(drillBlockPoint.DrillBlock.Id)
                            .FirstOrDefault(x => x.Sequence == drillBlockPoint.Sequence);
            if (sequenceIsExist != null) throw new DrillingException($"Значение Sequence должно быть уникальным " +
                $"в рамках каждого блока обуривания. Значение {drillBlockPoint.Sequence} уже задано для данного блока");
        }
    }
}
