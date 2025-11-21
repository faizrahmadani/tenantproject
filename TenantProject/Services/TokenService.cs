using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TenantProject.Data;

namespace TenantProject.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;
    private readonly MainDatabaseContext _context;

    public TokenService(IConfiguration configuration, MainDatabaseContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public string CreateJwtToken(IdentityUser user)
    {
        // Create claims
        var claims = new List<Claim>
        {
            new Claim("id", user.Id),   // ID user
            new Claim("name", user.UserName),       // Username
            new Claim("email", user.Email)          // Email
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); // from appsettings
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],// from appsettings
            _configuration["Jwt:Audience"],// from appsettings
            claims, // all claims from above        
            expires: DateTime.Now.AddMinutes(3), // expired berapa menit
            signingCredentials: credentials // credentials from above
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}