using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Models;

namespace ResturantReservation.Db.Repositories
{
    public class OrderRepository:IBaseRepository<Order>
    {
    private RestaurantReservationDbContext _context;
    private DbSet<Order> _dbSet;
    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
        _dbSet = _context.Orders;
    }

    public async Task Add(Order entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var item = await _dbSet.FirstOrDefaultAsync(d => d.OrderId == id);
        if (item is not null)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Order entity)
    {
        var item = await _dbSet.FirstOrDefaultAsync(d => d.OrderId == entity.OrderId);
        if (item is not null)
        {
            item.OrderDate=entity.OrderDate;
            await _context.SaveChangesAsync();
        }
    }

}

}
