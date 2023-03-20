using Drilling.Exceptions;
using Drilling.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drilling.Infrastructure.Repositories
{
    public class HoleRepository : IHoleRepository
    {
        private readonly DrillingContext _context;

        public HoleRepository(DrillingContext context)
        {
            _context = context;
        }

        public async Task<Hole> AddAsync(Hole hole)
        {
            await _context.Holes.AddAsync(hole);
            await _context.SaveChangesAsync();
            return await _context.Holes.FirstOrDefaultAsync(x => x.Id == hole.Id);
        }

        public async Task<Hole> GetByIdAsync(Guid id)
        {
            var result = await _context.Holes.Include(x => x.DrillBlock).FirstOrDefaultAsync(x => x.Id == id);
            if(result== null) throw new EntityNotFoundException($"Hole с id = {id} не найден");
            return result;
        }

        public async Task<Hole> EditAsync(Hole hole)
        {
            var entity = await _context.Holes.FirstOrDefaultAsync(x => x.Id == hole.Id);
            if (entity == null) throw new EntityNotFoundException($"Скважина с id = {hole.Id} не найдена");
            _context.Holes.Attach(entity);
            entity.Name = hole.Name;
            entity.Depth = hole.Depth;
            entity.DrillBlock=hole.DrillBlock;

            await _context.SaveChangesAsync();
            return await _context.Holes.FirstOrDefaultAsync(x => x.Id == hole.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Holes.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) throw new EntityNotFoundException($"Скважина с id = {id} не найдена");
            _context.Holes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public List<Hole> GetAll()
        {
            var result = _context.Holes.Include(x=>x.DrillBlock).ToList();
            return result;
        }
    }
}
