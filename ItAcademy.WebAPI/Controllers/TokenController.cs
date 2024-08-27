using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ItAcademy.Database.Entities;
using ItAcademy.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace ItAcademy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public TokenController(IConfiguration configuration, IUserService userService, ITokenService tokenService)
    {
        _configuration = configuration;
        _userService = userService;
        _tokenService = tokenService;
    }

    //todo add model for refreshToken
    [HttpPost("/refresh/")]
    public async Task<IActionResult> Refresh([FromBody] Guid refreshToken,
        CancellationToken cancellationToken = default)
    {
        if (await _tokenService.RefreshTokenCorrect(refreshToken, cancellationToken))
        {
            var user = await _userService.GetUserDataByRefreshToken(refreshToken, cancellationToken);
            if (user != null)
            {
                var data = await GenerateTokenPair(user.Id, user.RoleName);
                
                await _tokenService.RemoveToken(refreshToken); //todo need to be implemented
                
                return Ok(new { AccessToken = data.Item1, refreshToken = data.Item2});

            }
        }
        return NotFound();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model,
        CancellationToken cancellationToken = default)
    {
        if (!await _userService.CheckIsEmailRegisteredAsync(model.Email, cancellationToken) ||
            !await _userService.CheckPassword(model.Email, model.Password, cancellationToken))
        {
            return Unauthorized();
        }

        var userRole = await _userService.GetUserRoleByEmailAsync(model.Email, cancellationToken);
        var userId = await _userService.GetUserIdByEmailAsync(model.Email, cancellationToken);

        if (string.IsNullOrWhiteSpace(userRole) || !userId.HasValue)
        {
            return StatusCode(500);
        }

        var data = await GenerateTokenPair(userId.Value, userRole);
        
        return Ok(new { AccessToken = data.Item1, RefreshToken = data.Item2});

    }

    [HttpPatch("/revoke/{id}")]
    public async Task<IActionResult> Revoke(Guid id,
        CancellationToken cancellationToken = default)
    {
        //set IsRevoked true for refreshToken 
        return NotFound();
    }

    private async Task<(string, string)> GenerateTokenPair(Guid userId, string userRole)
    {
        var jwt = await _tokenService.GenerateJwtTokenString(userId, userRole);
        var deviceInfo = "localhost";
        var rt = await _tokenService.GenerateRefreshToken(userId, deviceInfo);
        return (jwt, rt);
    }
}

