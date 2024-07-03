using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Models;

namespace ResturantReservation.Db.Repositories
{
    public class TableRepository : IBaseRepository<Table>
    {
        private RestaurantReservationDbContext _context;
        private DbSet<Table> _dbSet;
        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _dbSet = _context.Tables;
        }

        public async Task Add(Table entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _dbSet.FirstOrDefaultAsync(d => d.TableId == id);
            if (item is not null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Table entity)
        {
            var item = await _dbSet.FirstOrDefaultAsync(d => d.TableId == entity.TableId);
            if (item is not null)
            {
                item.Capacity = entity.Capacity;
                await _context.SaveChangesAsync();
            }
        }
    }
}
