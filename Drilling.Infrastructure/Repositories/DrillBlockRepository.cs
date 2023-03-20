using Drilling.Exceptions;
using Drilling.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drilling.Infrastructure.Repositories
{
    public class DrillBlockRepository : IDrillBlockRepository
    {
        private readonly DrillingContext _context;

        public DrillBlockRepository(DrillingContext context)
        {
            _context = context;
        }

        public async Task<DrillBlock> Add(DrillBlock drillBlock)
        {
            await _context.DrillBlocks.AddAsync(drillBlock);
            await _context.SaveChangesAsync();
            return await _context.DrillBlocks.FirstOrDefaultAsync(x=>x.Id==drillBlock.Id);           
        }

        public async Task<DrillBlock> GetById(Guid id)
        {
            var result = await _context.DrillBlocks.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<DrillBlock> Edit(DrillBlock drillBlock)
        {
            var entity = await _context.DrillBlocks.FirstOrDefaultAsync(x => x.Id == drillBlock.Id);
            if(entity==null) throw new EntityNotFoundException($"Блок обуривания с id = {drillBlock.Id} не найден");
            _context.DrillBlocks.Attach(entity);
            entity.Name = drillBlock.Name;
            entity.UpdateTime= drillBlock.UpdateTime;
            await _context.SaveChangesAsync();
            return await _context.DrillBlocks.FirstOrDefaultAsync(x => x.Id == drillBlock.Id);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.DrillBlocks.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) throw new EntityNotFoundException($"Блок обуривания с id = {id} не найден");
            _context.DrillBlocks.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public List<DrillBlock> GetAll()
        {
            var result = _context.DrillBlocks.ToList();
            return result;
        }
    }
}
