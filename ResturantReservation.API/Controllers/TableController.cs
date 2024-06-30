using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantReservation.API.DTO;
using ResturantReservation.Db;
using ResturantReservation.Db.Models;

namespace ResturantReservation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase, IBaseController<TableDto>
    {
        private RestaurantReservationDbContext _context;

        public TableController(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TableDto entity)
        {
            var table = new Table
            {
                ResturantId = entity.ResturantId,
                Capacity = entity.Capacity,
            };
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return Ok($"new table with Id={table.TableId} sucessfully added");
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.Tables.Where(t => t.TableId == id).FirstOrDefaultAsync();
            if (item is not null)
            {
                _context.Tables.Remove(item);
                await _context.SaveChangesAsync();
                return Ok($"item with ${item.TableId} successfully removed");
            }
            return NotFound("not removed");
        }
        [HttpPut]
        public async Task<ActionResult> Edit(int id, TableDto entity)
        {
            var item = await _context.Tables.FirstOrDefaultAsync(t => t.TableId == id);
            if (item is not null)
            {
                item.ResturantId = entity.ResturantId;
                item.Capacity = entity.Capacity;
                await _context.SaveChangesAsync();
                return Ok("updated successfully");
            }
            return BadRequest("not updated successfully");
        }
        [HttpGet]
        public async Task<ActionResult<TableDto>> Get(int id)
        {
            var item = await _context.Tables.Where(t => t.TableId == id).FirstOrDefaultAsync();
            if (item is not null)
            {
                var table = new TableDto
                {
                    TableId = item.TableId,
                    Capacity = item.Capacity,
                    ResturantId = item.ResturantId
                };
                return Ok(table);
            }
            return NotFound("not found");
        }
        [HttpGet("/tables")]
        public async Task<ActionResult<List<TableDto>>> GetAll()
        {
            try
            {
                var items = await _context.Tables.ToListAsync();
                var tables = items.Select(table => new TableDto
                {
                    TableId = table.TableId,
                    Capacity = table.Capacity,
                    ResturantId = table.ResturantId,

                }).ToList();
                return Ok(tables);
            }
            catch
            {
                return NotFound("no items");
            }
        }

    }
}
