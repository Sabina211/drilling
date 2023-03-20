using Drilling.Exceptions;
using Drilling.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drilling.Infrastructure.Repositories
{
    public class HolePointRepository : IHolePointRepository
    {
        private readonly DrillingContext _context;

        public HolePointRepository(DrillingContext context)
        {
            _context = context;
        }

        public async Task<HolePoint> AddAsync(HolePoint holePoint)
        {
            await _context.HolePoints.AddAsync(holePoint);
            await _context.SaveChangesAsync();
            return await _context.HolePoints.FirstOrDefaultAsync(x => x.Id == holePoint.Id);
        }

        public async Task<HolePoint> GetByIdAsync(Guid id)
        {
            var result = await _context.HolePoints.Include(x => x.Hole.DrillBlock).FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) throw new EntityNotFoundException($"HolePoint с id = {id} не найден");
            return result;
        }

        public async Task<HolePoint> EditAsync(HolePoint holePoint)
        {
            var entity = await _context.HolePoints.FirstOrDefaultAsync(x => x.Id == holePoint.Id);
            if (entity == null) throw new EntityNotFoundException($"HolePoint с id = {holePoint.Id} не найден");
            _context.HolePoints.Attach(entity);
            entity.Hole = holePoint.Hole;
            entity.X = holePoint.X;
            entity.Y = holePoint.Y;
            entity.Z = holePoint.Z;

            await _context.SaveChangesAsync();
            return await _context.HolePoints.FirstOrDefaultAsync(x => x.Id == holePoint.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.HolePoints.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) throw new EntityNotFoundException($"HolePoint с id = {id} не найден");
            _context.HolePoints.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public List<HolePoint> GetAll()
        {
            var result = _context.HolePoints.Include(x => x.Hole.DrillBlock).ToList();
            return result;
        }
    }
}
