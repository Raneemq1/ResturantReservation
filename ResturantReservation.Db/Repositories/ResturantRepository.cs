using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Models;

namespace ResturantReservation.Db.Repositories
{
    public class ResturantRepository:IBaseRepository<Resturant>
    {
    private RestaurantReservationDbContext _context;
    private DbSet<Resturant> _dbSet;
    public ResturantRepository(RestaurantReservationDbContext context)
    {
        _context = context;
        _dbSet = _context.Resturants;
    }

    public async Task Add(Resturant entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var item = await _dbSet.FirstOrDefaultAsync(d => d.ResturantId == id);
        if (item is not null)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Resturant entity)
    {
        var item = await _dbSet.FirstOrDefaultAsync(d => d.ResturantId == entity.ResturantId);
        if (item is not null)
        {
            item.Address = entity.Address;
            item.PhoneNumber = entity.PhoneNumber;
            await _context.SaveChangesAsync();
        }
    }

        public async Task<int> TotalRevenue(int resturantId)
        {
            return await _dbSet.Where(r=>r.ResturantId==resturantId).Select(r=>_context.TotalRevenue(r.ResturantId)).FirstAsync();
            }

    }

}
