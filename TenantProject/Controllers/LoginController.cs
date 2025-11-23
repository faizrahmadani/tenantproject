using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TenantProject.Model.DTO;
using TenantProject.Services;

namespace TenantProject.Controllers;
[Route("api")]
[ApiController]
public class LoginController: ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly TokenService _tokenService;
    public LoginController(UserManager<IdentityUser> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    //[HttpPost]
    //[Route("Register")]
    //public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    //{
    //    var user = new IdentityUser
    //    {
    //        UserName = dto.Username,
    //        Email = dto.Email,
    //    };
    //    var identityResult = await _userManager.CreateAsync(user, dto.Password);
    //    if (identityResult.Succeeded)
    //    {
    //        return Ok(new { message = "User was registered! Now Login!" });
    //    }
    //    return BadRequest("Something went wrong!");
    //}

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user != null)
        {
            var checkPasswordResult = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (checkPasswordResult)
            {
                var jwtToken = _tokenService.CreateJwtToken(user);

                var response = new LoginResponseDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Token = jwtToken,
                };
                return Ok(response);
            }
            return BadRequest("Password Incorrect!");
        }
        return BadRequest("Username or Password Incorrect!");
    }
}