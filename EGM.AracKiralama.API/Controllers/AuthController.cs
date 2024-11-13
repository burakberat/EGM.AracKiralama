using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using Infrastructure.Model.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EGM.AracKiralama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto item)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ResultDto<JwtDto>.Error("Geçerli bir model değil"));
            }
            var result = await _authService.LoginAsync(item);
            return Ok(result);
        }
    }
}

