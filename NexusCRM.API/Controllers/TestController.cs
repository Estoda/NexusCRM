using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusCRM.API.Common;
using NexusCRM.Application.Interfaces;

namespace NexusCRM.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TestController : ControllerBase
{
    private readonly ITenantService _tenantService;

    public TestController(ITenantService tenantService) => _tenantService = tenantService;

    [HttpGet("me")]
    public IActionResult GetCurrentTenant()
    {
        var result = new
        {
            UserId = _tenantService.GetCurrentUserId(),
            CompanyId = _tenantService.GetCurrentCompanyId(),
            Role = _tenantService.GetCurrentUserRole(),
            IsSuperAdmin = _tenantService.IsSuperAdmin()
        };

        return Ok(ApiResponse<object>.OK(result, "Tenant information retrieved successfully."));
    }
}
