namespace NexusCRM.Application.Interfaces;

public interface ITenantService
{
    Guid GetCurrentCompanyId();
    Guid GetCurrentUserId();
    string GetCurrentUserRole();
    bool IsSuperAdmin();
}
