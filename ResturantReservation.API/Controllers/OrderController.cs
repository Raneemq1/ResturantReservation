using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantReservation.API.DTO;
using ResturantReservation.API.Validators;
using ResturantReservation.Db;
using ResturantReservation.Db.Models;

namespace ResturantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase, IBaseController<OrderDto>
    {
        private RestaurantReservationDbContext _context;

        public OrderController(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Add(OrderDto entity)
        {
            OrderDtoValidator validator = new();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                var order = new Order
                {
                    OrderId = entity.OrderId,
                    OrderDate = entity.OrderDate,
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return Ok($"order with id={order.OrderId} added successfully");
            }
            else
            {
                return BadRequest(result.ToString());
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            if (item != null)
            {
                _context.Orders.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("removed successfully");
            }
            return NotFound("not removed");
        }
        [HttpPut]
        public async Task<ActionResult> Edit(int id, OrderDto entity)
        {
            OrderDtoValidator validator = new();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                var item = await _context.Orders.FirstOrDefaultAsync(order => order.OrderId == id);
                if (item is not null)
                {
                    item.OrderDate = entity.OrderDate;
                    item.EmployeeId = entity.EmployeeId;
                    item.ReservationId = entity.ReservationId;
                    item.TotalAmount = entity.TotalAmount;
                    await _context.SaveChangesAsync();
                    return Ok("updated successfully");
                }
                return NotFound("item not found to update");
            }
            else
            {
                return BadRequest(result.ToString());
            }
        }
        [HttpGet]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var item = await _context.Orders.FirstOrDefaultAsync(Order => Order.OrderId == id);
            if (item is not null)
            {
                var order = new OrderDto
                {
                    OrderDate = item.OrderDate,
                    OrderId = item.OrderId,
                    EmployeeId = item.EmployeeId,
                    ReservationId = item.ReservationId,
                    TotalAmount = item.TotalAmount,
                };
                return Ok(order);
            }
            return NotFound("not found");
        }
        [HttpGet("/orders")]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            try
            {
                var items = await _context.Orders.ToListAsync();
                var orders = items.Select(order => new OrderDto
                {
                    OrderDate = order.OrderDate,
                    OrderId = order.OrderId,
                    EmployeeId = order.EmployeeId,
                    ReservationId = order.ReservationId,
                    TotalAmount = order.TotalAmount,
                }).ToList();
                return Ok(orders);
            }
            catch
            {
                return NotFound("no items yet");
            }
        }
        [HttpGet("/api/reservations/{reservationId}/orders")]
        public async Task<ActionResult<List<OrderMenuItem>>> ListOrdersAndMenuItemsByReservationId(int reservationId)
        {
            try
            {
                var reservations = await _context.Orders.Where(order => order.ReservationId == reservationId).GroupJoin(_context.OrderItems, order => order.OrderId,
                    orderItem => orderItem.OrderId, (order, orderItem) => new OrderMenuItem
                    (order.OrderId, orderItem.Select(item => item.MenuItem).FirstOrDefault())).ToListAsync();

                return Ok(reservations);
            }
            catch
            {
                return NotFound("no items yet");
            }

        }
        [HttpGet("/api/reservations/{reservationId}/menu-items")]
        public async Task<ActionResult<List<MenuItem>>> ListOrderedMenuItemsByReservationId(int reservationId)
        {
            try
            {
                var reservations = await _context.Orders.Where(order => order.ReservationId == reservationId).GroupJoin(_context.OrderItems,
                   order => order.OrderId,
                   orderItem => orderItem.OrderId, (order, orderItem) => orderItem.Select(o => o.MenuItem).FirstOrDefault()
                   ).OrderBy(m => m.MenuItemId).ToListAsync();
                return Ok(reservations);
            }
            catch
            {
                return NotFound("no items yet");
            }
        }
        [HttpGet("/api/employees/{employeeId}/average-order-amount")]
        public async Task<ActionResult<double>> AvgAmountOfOrdersByEmployeeId(int employeeId)
        {
            var avg = await _context.Orders.Where(o => o.EmployeeId == employeeId).Select(o => o.TotalAmount).AverageAsync();
            return Ok(avg);
        }
    }
}
