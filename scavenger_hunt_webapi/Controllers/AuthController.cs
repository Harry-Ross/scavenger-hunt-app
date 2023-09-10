using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scavenger_hunt_webapi.DTOs;
using scavenger_hunt_webapi.Entities;
using scavenger_hunt_webapi.Services;

namespace scavenger_hunt_webapi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ScavengerHuntContext _context;
        private readonly AuthenticationService _authService;

        public AuthController(
            IConfiguration configuration, 
            ScavengerHuntContext dbContext, 
            AuthenticationService authService
        )
        {
            _configuration = configuration;
            _context = dbContext; 
            _authService = authService;
        }

     
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login ([FromBody] LoginInput input)
        {
            if (input is null 
                || string.IsNullOrEmpty(input.Email) 
                || string.IsNullOrEmpty(input.Password)
            )
            {
                return BadRequest();
            }
            var user = await _context.Users.Where(user => user.Email == input.Email).ToListAsync();
            Console.WriteLine(user);
            AuthResponse res = new ();
            return Ok(res);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register ([FromBody] RegisterInput input)
        {
            if (input is null)
            {
                return BadRequest();
            }

            var user = new User { 
                FirstName = input.FirstName, 
                LastName = input.LastName,
                Email = input.Email,
                Password = input.Password,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = _authService.GenerateJWT(user);
            
            var res = new AuthResponse { Token = token };
            return Ok(res);
        }
    }
}
