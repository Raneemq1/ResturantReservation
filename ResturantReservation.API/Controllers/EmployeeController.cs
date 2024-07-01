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
    public class EmployeeController : ControllerBase, IBaseController<EmployeeDto>
    {
        private RestaurantReservationDbContext _context;

        public EmployeeController(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Add(EmployeeDto entity)
        {
            var employee = new Employee
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                ResturantId = entity.ResturantId,
                Position = entity.Position
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok($"employee with id={employee.EmployeeId} added successfully");
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == id);
            if (item is not null)
            {
                _context.Employees.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("removed successfully");
            }
            return NotFound("no item found to remove");
        }
        [HttpPut]
        public async Task<ActionResult> Edit(int id, EmployeeDto entity)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == id);
            if (item is not null)
            {
                item.FirstName = entity.FirstName;
                item.LastName = entity.LastName;
                item.ResturantId = entity.ResturantId;
                item.Position = entity.Position;
                await _context.SaveChangesAsync();
                return Ok("updated successfully");
            }
            return NotFound("no item update to remove");
        }
        [HttpGet]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var item = await _context.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == id);
            if (item is not null)
            {
                var employee = new EmployeeDto
                {
                    EmployeeId = id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Position = item.Position,
                    ResturantId = item.ResturantId
                };
                return Ok(employee);
            }
            return NotFound("No item found with this id");
        }
        [HttpGet("/employees")]
        public async Task<ActionResult<List<EmployeeDto>>> GetAll()
        {
            try
            {
                var items = await _context.Employees.ToListAsync();
                var employees = items.Select(emp => new EmployeeDto 
                {
                    EmployeeId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Position = emp.Position,
                    ResturantId = emp.ResturantId
                }).ToList();
                return Ok(employees);
            }
            catch
            {
                return NotFound("no items yet");
            }
        }
        [HttpGet("/api/employees/managers")]
        public async Task<ActionResult<List<EmployeeDto>>> GetManagers()
        {
            try
            {
                await Console.Out.WriteLineAsync(EmployeePosition.Manager.ToString());
                var items = await _context.Employees.Where(emp => emp.Position.Equals(EmployeePosition.Manager.ToString())).ToListAsync();
                var employees = items.Select(emp => new EmployeeDto
                {
                    EmployeeId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Position = emp.Position,
                    ResturantId = emp.ResturantId
                }).ToList();
                return Ok(employees);
            }
            catch
            {
                return NotFound("no items yet");
            }
        }
       
    }
}
