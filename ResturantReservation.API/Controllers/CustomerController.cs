using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantReservation.API.DTO;
using ResturantReservation.Db;
using ResturantReservation.Db.Models;

namespace ResturantReservation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase, IBaseController<CustomerDto>
    {
        private RestaurantReservationDbContext _context;

        public CustomerController(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Add(CustomerDto entity)
        {
            var customer = new Customer
            {
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok($"customer with Id={customer.CustomerId} added successfully");
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == id);
            if (item is not null)
            {
                _context.Customers.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("removed successfully");
            }
            return NotFound("no item found with this Id to remove");
        }
        [HttpPut]
        public async Task<ActionResult> Edit(int id, CustomerDto entity)
        {
            var item = await _context.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == id);
            if (item is not null)
            {
                item.PhoneNumber = entity.PhoneNumber;
                item.FirstName = entity.FirstName;
                item.LastName = entity.LastName;
                item.Email = entity.Email;
                await _context.SaveChangesAsync();
                return Ok("updated successfully");
            }
            return NotFound("no item found with this Id to update");
        }
        [HttpGet]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            var item = await _context.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == id);
            if (item is not null)
            {
                var customer = new CustomerDto
                {
                    CustomerId = id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                };
                return Ok(customer);
            }
            return NotFound("no customer with this id found");
        }
        [HttpGet("/customers")]
        public async Task<ActionResult<List<CustomerDto>>> GetAll()
        {
            try
            {
                var items = await _context.Customers.ToListAsync();
                var customers = items.Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                }).ToList();
                return Ok(customers);
            }
            catch
            {
                return NotFound("no items yet");
            }
        }
    }
}
