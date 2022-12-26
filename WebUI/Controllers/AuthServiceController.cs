using Domain;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using ReactNoteAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthServiceController : ControllerBase
    {

        private IConfiguration configuration;

        public AuthServiceController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var result = await AuthServiceRepository.CreateNewUser(user);
            var authRepo = new AuthServiceRepository(configuration);


            if (result != null)
            {
                var authenticated = authRepo.LoginCurrentUser(user);
                return Ok(authenticated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user) {
            var authRepo = new AuthServiceRepository(configuration);
            var result = authRepo.LoginCurrentUser(user);

            if (result == null) {
                return NotFound();
            }


            return Ok(result);
        
        }

    }
}
