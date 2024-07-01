using Microsoft.AspNetCore.Mvc;

namespace ResturantReservation.API.Controllers
{
    public interface IBaseController<T>
    {
        public Task<ActionResult> Add(T entity);
        public Task<ActionResult> Edit(int id,T entity);
        public Task<ActionResult> Delete(int id);
        public Task<ActionResult<T>> Get(int id);
        public Task<ActionResult<List<T>>> GetAll();
    }
}
