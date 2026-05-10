using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using NexusCRM.Application.Interfaces;

namespace NexusCRM.Infrastructure.Services;

public class TenantService : ITenantService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal GetUser()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user == null || !user.Identity!.IsAuthenticated)
            throw new UnauthorizedAccessException("User is not authenticated.");

        return user;
    }

    public Guid GetCurrentUserId()
    {
        var userId = GetUser().FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException("User ID not found in token.");

        return Guid.Parse(userId);
    }

    public Guid GetCurrentCompanyId()
    {
        var companyId = GetUser().FindFirstValue("companyId");

        if (string.IsNullOrEmpty(companyId))
            throw new UnauthorizedAccessException("Company ID not found in token.");

        return Guid.Parse(companyId);
    }

    public string GetCurrentUserRole()
    {
        var role = GetUser().FindFirstValue(ClaimTypes.Role);

        if (string.IsNullOrEmpty(role))
            throw new UnauthorizedAccessException("Role not found in token.");

        return role;
    }

    public bool IsSuperAdmin()
    {
        return GetCurrentUserRole() == "SuperAdmin";
    }
}