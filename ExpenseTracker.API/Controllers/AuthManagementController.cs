using ExpenseTracker.API.Configurations;
using ExpenseTracker.Entities.Dtos;
using ExpenseTracker.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthManagementController : ControllerBase
{
    private readonly ILogger<AuthManagementController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtConfig _jwtConfig;

    public AuthManagementController(
        ILogger<AuthManagementController> logger, 
        UserManager<IdentityUser> userManager,
        IOptionsMonitor<JwtConfig> optionsMonitor)
    {
        _logger = logger;
        _userManager = userManager;
        _jwtConfig = optionsMonitor.CurrentValue;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto request)
    {
        if (ModelState.IsValid)
        {
            var emailExist = await _userManager.FindByEmailAsync(request.Email);

            if (emailExist != null)
                return BadRequest("Emai already exist");

            IdentityUser newUser = new()
            {
                Email = request.Email,
                UserName = request.Email,
            };

            var isCreated = await _userManager.CreateAsync(newUser, request.Password);

            if (isCreated.Succeeded)
            {

                var token = GenerateJwtToken(newUser);

                return Ok(new RegistrationRequestResponse()
                {
                    Result = true,
                    Token = token,
                });
            }

            return BadRequest(isCreated.Errors.Select(x => x.Description).ToList());
        }

        return BadRequest("Invalid request payload");
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto request)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return BadRequest("Invalid authentication");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (isPasswordValid)
            {
                var token = GenerateJwtToken(user);

                return Ok(new LoginRequestResponse { Token = token, Result = true });
            }

            return BadRequest("Invalid password");

        }

        return BadRequest("Invalid request payload");
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }),

            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return jwtToken;
    }
}
