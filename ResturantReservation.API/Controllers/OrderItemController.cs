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

    public class OrderItemController : ControllerBase, IBaseController<OrderItemDto>
    {
        private RestaurantReservationDbContext _context;

        public OrderItemController(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Add(OrderItemDto entity)
        {
            OrderItemDtoValidator validator = new();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                var order = new OrderItem
                {
                    OrderId = entity.OrderId,
                    Quantity = entity.Quantity,
                    MenuItemId = entity.MenuItemId,
                };
                _context.OrderItems.Add(order);
                await _context.SaveChangesAsync();
                return Ok($"new orderItem with Id={order.OrderItemId} successfully added");
            }
            return BadRequest(result.ToString());
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.OrderItems.FirstOrDefaultAsync(item => item.OrderItemId == id);
            if (item is not null)
            {
                _context.OrderItems.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("removed successfully");
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult> Edit(int id, OrderItemDto entity)
        {
            OrderItemDtoValidator validator = new();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                var item = await _context.OrderItems.FirstOrDefaultAsync(order => order.OrderItemId == id);
                if (item is not null)
                {
                    item.OrderId = entity.OrderId;
                    item.Quantity = entity.Quantity;
                    item.MenuItemId = entity.MenuItemId;
                    await _context.SaveChangesAsync();
                    return Ok("update successfully");
                }
                return NotFound("Not updated");
            }
            return BadRequest(result.ToString());
        }
        [HttpGet]
        public async Task<ActionResult<OrderItemDto>> Get(int id)
        {
            var item = await _context.OrderItems.FirstOrDefaultAsync(o => o.OrderId == id);
            if (item is not null)
            {
                var orderItem = new OrderItemDto
                {
                    OrderId = item.OrderId,
                    OrderItemId = item.OrderItemId,
                    Quantity = item.Quantity,
                    MenuItemId = item.MenuItemId,
                };
                return Ok(orderItem);
            }
            return NotFound("not found");
        }
        [HttpGet("/OrderItems")]
        public async Task<ActionResult<List<OrderItemDto>>> GetAll()
        {
            try
            {
                var items = await _context.OrderItems.ToListAsync();
                var orderItems = items.Select(order => new OrderItemDto
                {
                    OrderId = order.OrderId,
                    OrderItemId = order.OrderItemId,
                    Quantity = order.Quantity,
                    MenuItemId = order.MenuItemId,
                }).ToList();
                return Ok(orderItems);
            }
            catch
            {
                return NotFound("no items yet");
            }
        }
    }
}
