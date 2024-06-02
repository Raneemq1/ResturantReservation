using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Models;

namespace ResturantReservation.Db.Repositories
{
    public class OrderItemRepository:IBaseRepository<OrderItem>
    {
    private RestaurantReservationDbContext _context;
    private DbSet<OrderItem> _dbSet;
    public OrderItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
        _dbSet = _context.OrderItems;
    }

    public async Task Add(OrderItem entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var item = await _dbSet.FirstOrDefaultAsync(d => d.OrderItemId == id);
        if (item is not null)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(OrderItem entity)
    {
        var item = await _dbSet.FirstOrDefaultAsync(d => d.OrderItemId == entity.OrderItemId);
        if (item is not null)
        {
            item.Quantity = entity.Quantity;
            await _context.SaveChangesAsync();
        }
    }

}

}
