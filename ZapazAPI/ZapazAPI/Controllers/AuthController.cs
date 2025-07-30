using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZapazAPI.Models;
using ZapazAPI.Services.ZapazService;

namespace ZapazAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IZapazService _zapazService;
        public AuthController(IZapazService zapazService) => _zapazService = zapazService;

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserDto request) 
        {
            var result = await _zapazService.RegisterAsync(request);
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request) 
        {
            var result = await _zapazService.LoginAsync(request);
            return Ok(result);  
        }
    }
}
