using Microsoft.EntityFrameworkCore;

namespace ResturantReservation.Db.Repositories
{
    public interface IBaseRepository<T> 
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
