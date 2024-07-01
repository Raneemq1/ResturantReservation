using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantReservation.API.Helpers;
using ResturantReservation.Db;
using ResturantReservation.Db.Models;

namespace ResturantReservation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private RestaurantReservationDbContext _context;
        private IConfiguration _config;
        
        public UserController(RestaurantReservationDbContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(User user)
        {
            if (user is null) return BadRequest("no enrty info");
            JwtHelper helper = new(_config);
            byte[] encPassword = new byte[user.UserPassword.Length];
            encPassword = System.Text.Encoding.UTF8.GetBytes(user.UserPassword);
            user.UserPassword=Convert.ToBase64String(encPassword);

            var token = helper.GenerateToken(user);
            if (helper.ValidateToken(token))
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(new {Token=token});
            }
            return BadRequest("Invalid Token");
        }
    }
}
