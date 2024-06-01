using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Models;

namespace ResturantReservation.Db.Repositories
{
    public class ReservationRepository : IBaseRepository<Reservation>
    {
        private RestaurantReservationDbContext _context;
        private DbSet<Reservation> _dbSet;
        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _dbSet = _context.Reservations;
        }

        public async Task Add(Reservation entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _dbSet.FirstOrDefaultAsync(d => d.ReservationId == id);
            if (item is not null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Reservation entity)
        {
            var item = await _dbSet.FirstOrDefaultAsync(d => d.ReservationId == entity.ReservationId);
            if (item is not null)
            {
                item.PartySize = entity.PartySize;
                item.ReservationDate = entity.ReservationDate;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Reservation>> GetReservationsByCustomer(int CustomerId)
        {
            return await _dbSet.Where(r=>r.CustomerId==CustomerId).ToListAsync();
        }

    }

}