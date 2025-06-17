using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokemonApi.Application.Dtos.AuthDtos;
using PokemonApi.Infrastructure.Implementation.Services.Security;

namespace PokemonApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AuthService _authService;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, AuthService authService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterDto(RegisterDto registerDto)
        {
            var user = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { StatusCode = 200, message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(dto.Login)
                           ?? await _userManager.FindByNameAsync(dto.Login);

            if (user == null)
                return Unauthorized("Invalid credentials");

            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
                return Unauthorized("Invalid credentials");

            var token = _authService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
