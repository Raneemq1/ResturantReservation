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
    public class RestervationController : ControllerBase, IBaseController<ReservationDto>
    {
        private RestaurantReservationDbContext _context;

        public RestervationController(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Add(ReservationDto entity)
        {
            var reservation = new Reservation
            {
                ReservationDate=entity.ReservationDate,
                ResturantId=entity.ResturantId,
                CustomerId=entity.CustomerId,
                PartySize=entity.PartySize,
                TableId=entity.TableId,
            };
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return Ok($"reservation with Id={reservation.ReservationId} added successfully");
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var item=await _context.Reservations.FirstOrDefaultAsync(res=>res.ReservationId==id);   
            if(item is not null)
            {
                _context.Reservations.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("removed Successfully");
            }
            return BadRequest("not find item to remove it");
        }
        [HttpPut]
        public async Task<ActionResult> Edit(int id, ReservationDto entity)
        {
            var item=await _context.Reservations.FirstOrDefaultAsync(res=>res.ReservationId == id);
            if (item is not null)
            {
                item.ResturantId = entity.ResturantId;
                item.CustomerId = entity.CustomerId;
                item.PartySize = entity.PartySize;  
                item.TableId = entity.TableId;
                item.ReservationDate = entity.ReservationDate;
               await _context.SaveChangesAsync();
                return Ok($"updated reservation with Id={item.ReservationId} successfully");
            }
            return NotFound("Not updated");
        }
        [HttpGet]
        public async Task<ActionResult<ReservationDto>> Get(int id)
        {
            var item=await _context.Reservations.FirstOrDefaultAsync(res=>res.ReservationId==id);  
            if (item is not null) {
                var reservation = new ReservationDto
                {
                    ReservationId = item.ReservationId,
                    ReservationDate = item.ReservationDate,
                    ResturantId = item.ResturantId,
                    CustomerId = item.CustomerId,   
                    PartySize = item.PartySize,
                    TableId = item.TableId
                };
                return Ok(reservation);
            }
            return NotFound($"no item found with this id {id}");
        }
        [HttpGet("/reservations")]
        public async Task<ActionResult<List<ReservationDto>>> GetAll()
        {
            try
            {
                var items = await _context.Reservations.ToListAsync();
                var reservations = items.Select(res => new ReservationDto 
                {
                    ReservationId = res.ReservationId,
                    ReservationDate = res.ReservationDate,
                    ResturantId = res.ResturantId,
                    CustomerId = res.CustomerId,
                    PartySize = res.PartySize,
                    TableId = res.TableId
                }).ToList();
                return Ok(reservations);
            }
            catch
            {
                return NotFound("no items found yet");
            }

        }
        [HttpGet("/api/reservations/customer/{customerId}")]
        public async Task<ActionResult<ReservationDto>> GetReservationDetailByCustomerId(int customerId)
        {
            try
            {
                var items = await _context.Reservations.Where(res=>res.CustomerId==customerId).ToListAsync();
                var reservations = items.Select(res => new ReservationDto
                {
                    ReservationId = res.ReservationId,
                    ReservationDate = res.ReservationDate,
                    ResturantId = res.ResturantId,
                    CustomerId = res.CustomerId,
                    PartySize = res.PartySize,
                    TableId = res.TableId
                }).ToList();
                return Ok(reservations);
            }
            catch
            {
                return NotFound("no items found yet");
            }
        }
      
    }
}
