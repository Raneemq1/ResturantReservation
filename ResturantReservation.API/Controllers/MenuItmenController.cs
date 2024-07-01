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
    public class MenuItmenController : ControllerBase, IBaseController<MenuItemDto>
    {
        private RestaurantReservationDbContext _context;

        public MenuItmenController(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Add(MenuItemDto entity)
        {
            MenuItemDtoValidator validator = new();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                var menuItem = new MenuItem
                {
                    Name = entity.Name,
                    Price = entity.Price,
                    Description = entity.Description,
                    ResturantId = entity.ResturantId,
                };
                _context.MenuItems.Add(menuItem);
                await _context.SaveChangesAsync();
                return Ok($"menuItem with Id={menuItem.MenuItemId} added successfully");
            }
            else
            {
                return BadRequest(result.ToString());
            }

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.MenuItems.FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (item is not null)
            {
                _context.MenuItems.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("removed successfully");
            }
            return NotFound("not found");
        }
        [HttpPut]
        public async Task<ActionResult> Edit(int id, MenuItemDto entity)
        {
            MenuItemDtoValidator validator = new();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                var item = await _context.MenuItems.FirstOrDefaultAsync(m => m.MenuItemId == id);
                if (item is not null)
                {
                    item.ResturantId = entity.ResturantId;
                    item.Price = entity.Price;
                    item.Name = entity.Name;
                    item.Description = entity.Description;
                    await _context.SaveChangesAsync();
                    return Ok("successfully updated");
                }
                return NotFound("item not found to update it");
            }
            else
            {
                return BadRequest(result.ToString());
            }

        }
        [HttpGet]
        public async Task<ActionResult<MenuItemDto>> Get(int id)
        {
            var item = await _context.MenuItems.FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (item is not null)
            {
                var menuItem = new MenuItemDto
                {
                    MenuItemId = id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    ResturantId = item.ResturantId,
                };
                return Ok(menuItem);
            }
            return NotFound("no item found");
        }
        [HttpGet("/menuItems")]
        public async Task<ActionResult<List<MenuItemDto>>> GetAll()
        {
            try
            {
                var items = await _context.MenuItems.ToListAsync();
                var menuItems = items.Select(item => new MenuItemDto
                {
                    MenuItemId = item.MenuItemId,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    ResturantId = item.ResturantId,
                }).ToList();
                return Ok(menuItems);
            }
            catch
            {
                return NotFound("no items yet");
            }
        }
    }
}
