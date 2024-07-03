using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Models;

namespace ResturantReservation.Db.Repositories
{
    public class OrderRepository : IBaseRepository<Order>
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
                item.OrderDate = entity.OrderDate;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<OrderMenuItem>> ListOrdersAndMenuItems(int ReservationId)
        {
            return await _dbSet.Where(order => order.ReservationId == ReservationId)
                .Join(_context.OrderItems, order => order.OrderId, orderItem => orderItem.OrderId, (order, orderItem) => new { order.OrderId, orderItem })
                .Join(_context.MenuItems, joined => joined.orderItem.MenuItemId, menuItem => menuItem.MenuItemId, (joined, menuItem) => new OrderMenuItem(joined.OrderId, menuItem))
                .ToListAsync();
        }
        public async Task<IEnumerable<MenuItem>> ListOrderedMenuItems(int reservationId)
        {
            return await _dbSet
        .Where(order => order.ReservationId == reservationId)
        .Join(_context.OrderItems, order => order.OrderId, orderItem => orderItem.OrderId, (order, orderItem) => new { order, orderItem })
        .Join(_context.MenuItems, joined => joined.orderItem.MenuItemId, menuItem => menuItem.MenuItemId, (joined, menuItem) => menuItem)
        .ToListAsync();

        }
        public async Task<double> CalculateAverageOrderAmount(int employeeId)
        {
            return await _dbSet.Where(order => order.EmployeeId == employeeId)
                .GroupBy(order => order.EmployeeId)
                .Select(groupe => groupe.Average(order => order.TotalAmount)).FirstOrDefaultAsync();
        }
    }

}
