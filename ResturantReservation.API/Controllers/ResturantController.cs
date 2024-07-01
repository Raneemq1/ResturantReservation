using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantReservation.API.DTO;
using ResturantReservation.Db;
using ResturantReservation.Db.Models;

namespace ResturantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ResturantController : ControllerBase, IBaseController<ResturantDto>
    {
        private RestaurantReservationDbContext _context;

        public ResturantController(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Add(ResturantDto entity)
        {
            var resturant = new Resturant
            {
                ResturantId = entity.ResturantId,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                OpeningHours = entity.OpeningHours,
                Name = entity.Name
            };
            _context.Resturants.Add(resturant);
            await _context.SaveChangesAsync();
            return Ok($"resturant with id={resturant.ResturantId} sucessfully added");
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.Resturants.FirstAsync(res => res.ResturantId == id);
            if (item is not null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("removed sucessfully");
            }
            return BadRequest("error in remove");
        }
        [HttpPut]
        public async Task<ActionResult> Edit(int id, ResturantDto entity)
        {
            var item=_context.Resturants.FirstOrDefault(res=>res.ResturantId==id);
            if (item is not null)
            {
                item.Address = entity.Address;
                item.PhoneNumber = entity.PhoneNumber;
                item.OpeningHours = entity.OpeningHours;
                item.Name = entity.Name;
                await _context.SaveChangesAsync();
                return Ok($"item with id={item.ResturantId} successfully updated");
            }
            return NotFound("not found");
        }
        [HttpGet]
        public async Task<ActionResult<ResturantDto>> Get(int id)
        {
            var item=await _context.Resturants.FirstOrDefaultAsync(res=>res.ResturantId== id);  
            if(item is not null)
            {
                var resturant = new ResturantDto
                {
                    ResturantId = id,
                    Address = item.Address,
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber,
                    OpeningHours = item.OpeningHours,
                };
                return Ok(resturant);
            }
            return NotFound();
        }
        [HttpGet("/resturants")]
        public async Task<ActionResult<List<ResturantDto>>> GetAll()
        {
            try
            {
                var items = await _context.Resturants.ToListAsync();
                var resturants = items.Select(res => new ResturantDto
                {
                    ResturantId = res.ResturantId,
                    PhoneNumber = res.PhoneNumber,
                    OpeningHours = res.OpeningHours,
                    Address = res.Address,
                    Name = res.Name,

                }).ToList();
                return Ok(resturants);
            }
            catch
            {
                return NotFound("no items found");
            }
        }
    }
}
