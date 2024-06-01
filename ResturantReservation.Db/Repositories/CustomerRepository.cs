using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Models;

namespace ResturantReservation.Db.Repositories
{
    public class CustomerRepository : IBaseRepository<Customer>
    {
        private DbSet<Customer> _dbSet;
        private RestaurantReservationDbContext _context;

        public CustomerRepository(RestaurantReservationDbContext context)
        {
            _dbSet = context.Customers;
            _context = context;
        }
        public async Task Add(Customer entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _dbSet.FirstOrDefaultAsync(d => d.CustomerId == id);
            if (item is not null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Customer entity)
        {
            var item=await _dbSet.FirstOrDefaultAsync(d=>d.CustomerId==entity.CustomerId);
            if (item is not null)
            {
                item.FirstName = entity.FirstName;
                item.LastName = entity.LastName;
                item.Email = entity.Email;
                item.PhoneNumber = entity.PhoneNumber;
               await _context.SaveChangesAsync();
            }
        }
    }
}
