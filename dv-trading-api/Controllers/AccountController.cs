using dv_trading_api.Dtos.Account;
using dv_trading_api.Interfaces;
using dv_trading_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dv_trading_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newUser = new IdentityUser
                {
                    Email = registerDto.Email,
                    UserName = registerDto.Email
                };

                var result = await _userManager.CreateAsync(newUser, registerDto.Password);

                if (result.Succeeded)
                {
                    var addToRoleResult = await _userManager.AddToRoleAsync(newUser, "Admin");
                    if (addToRoleResult.Succeeded)
                    {
                        var registerResponseDto = new RegisterResponseDto
                        {
                            Email = newUser.Email,
                            Token = await _tokenService.GenerateToken(newUser)
                        };

                        return Ok(registerResponseDto);
                    }
                    else
                    {
                        return BadRequest( addToRoleResult.Errors);
                    }

                }
                else
                {
                    return BadRequest( result.Errors);
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
            
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Email.ToLower());

                if (user == null) return Unauthorized("Invalid credentials");
                
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

                if (result.Succeeded)
                {
                    var authResponse = new AuthResponseDto
                    {
                        Email = user.Email,
                        Token = await _tokenService.GenerateToken(user)
                    };

                    return Ok(authResponse);
                }
                else
                {
                    return BadRequest("Invalid login credentials");
                }
      
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("User signed out");
        }
    }
}

   

