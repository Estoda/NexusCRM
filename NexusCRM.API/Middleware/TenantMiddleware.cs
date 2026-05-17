using System.Net;
using System.Text.Json;
using NexusCRM.API.Common;
using NexusCRM.Application.Interfaces;
using NexusCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace NexusCRM.API.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next; // Middleware delegate

        public TenantMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var companyIdClaim = context.User.FindFirst("companyId")?.Value;
                var roleClaim = context.User.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;

                if (roleClaim != "SuperAdmin" && !string.IsNullOrEmpty(companyIdClaim))
                {
                    var companyId = Guid.Parse(companyIdClaim);

                    var company = await db.Companies
                        .FirstOrDefaultAsync(c => c.Id == companyId);

                    if (company == null || !company.IsActive)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        context.Response.ContentType = "application/json";

                        var response = ApiResponse<object>.Fail("Your company account has been suspended or does not exist.");
                        var json = JsonSerializer.Serialize(response);

                        await context.Response.WriteAsync(json);
                        return;
                    }
                }
            }
            await _next(context); // continue to controller
        }
    }
}
