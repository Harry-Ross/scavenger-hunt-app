using Microsoft.AspNetCore.Mvc;
using scavenger_hunt_webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace scavenger_hunt_webapi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ScavengerHuntContext _context;

        public AuthController(IConfiguration configuration, ScavengerHuntContext dbContext)
        {
            _configuration = configuration;
            _context = dbContext; 
        }

     
        [HttpPost("login")]
        public IActionResult Login (string username, string password)
        {
            return Ok("hello");
        }

        [HttpPost("register")]
        public IActionResult Register (string username, string password)
        {
            return Ok("hello");
        }
    }
}
