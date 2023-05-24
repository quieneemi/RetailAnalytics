using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RetAnal.Core.Interfaces;

namespace RetAnal.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController : Controller
{
    private const string SecretKey = "ThisIsMyVerySuperSecretKeyPleaseDontSteal";
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(3);
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var role = await _authService.LoginAsync(username, password);

        if (string.IsNullOrWhiteSpace(role))
            return Unauthorized();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            }),
            Expires = DateTime.UtcNow.Add(TokenLifetime),
            Issuer = "http://localhost",
            Audience = "http://localhost",
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = new { Token = tokenHandler.WriteToken(token) };

        return Ok(jwt);
    }
}