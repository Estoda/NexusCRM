using NexusCRM.Domain.Common;
using NexusCRM.Domain.Enums;
namespace NexusCRM.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Employee;
    public bool IsActive { get; set; } = true;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }

    // Navigation properties
    public Guid? CompanyId { get; set; } // nullable because SuperAdmin doesn't belong to any company.
    public Company? Company { get; set; }
}
