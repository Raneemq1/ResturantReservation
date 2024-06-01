using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Models;


namespace ResturantReservation.Db.Repositories
{
    public class EmployeeRepository:IBaseRepository<Employee>
    {
        private DbSet<Employee> _dbSet;
        private RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _dbSet = context.Employees;
            _context = context;
        }
        public async Task Add(Employee entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _dbSet.FirstOrDefaultAsync(d => d.EmployeeId == id);
            if (item is not null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Employee entity)
        {
            var item = await _dbSet.FirstOrDefaultAsync(d => d.EmployeeId == entity.EmployeeId);
            if (item is not null)
            {
                item.FirstName= entity.FirstName;
                item.LastName= entity.LastName;
                item.Position= entity.Position;
                await _context.SaveChangesAsync();
            }
        }
    }
}
