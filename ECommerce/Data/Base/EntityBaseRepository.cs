using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(l => l.Id == id);
            EntityEntry enetityEntry = _context.Entry<T>(entity);
            enetityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetById(int id)
        => await _context.Set<T>().FirstOrDefaultAsync(l => l.Id == id);

        public async Task Update(T entity, int id)
        {
            EntityEntry enetityEntry = _context.Entry<T>(entity);
            enetityEntry.State= EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
