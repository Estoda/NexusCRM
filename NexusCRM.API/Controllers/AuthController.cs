using Microsoft.AspNetCore.Mvc;
using NexusCRM.API.Common;
using NexusCRM.Application.DTOs.Auth;
using NexusCRM.Application.Interfaces;

namespace NexusCRM.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request);
        return Ok(ApiResponse<AuthResponse>.OK(result, "Registration successful"));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);
        return Ok(ApiResponse<AuthResponse>.OK(result, "Login successful"));
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
    {
        var result = await _authService.RefreshTokenAsync(refreshToken);
        return Ok(ApiResponse<AuthResponse>.OK(result, "Token refreshed successfully"));
    }
}
