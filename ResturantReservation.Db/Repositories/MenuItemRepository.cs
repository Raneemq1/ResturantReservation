using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Models;

namespace ResturantReservation.Db.Repositories
{
    public class MenuItemRepository:IBaseRepository<MenuItem>
    { 
    private RestaurantReservationDbContext _context;
    private DbSet<MenuItem> _dbSet;
    public MenuItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
        _dbSet = _context.MenuItems;
    }

    public async Task Add(MenuItem entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var item = await _dbSet.FirstOrDefaultAsync(d => d.MenuItemId == id);
        if (item is not null)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(MenuItem entity)
    {
        var item = await _dbSet.FirstOrDefaultAsync(d => d.MenuItemId == entity.MenuItemId);
        if (item is not null)
        {
            item.Price = entity.Price;
            item.Description = entity.Description;
            await _context.SaveChangesAsync();
        }
    }
}
}

