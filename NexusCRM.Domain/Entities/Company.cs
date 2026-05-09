using NexusCRM.Domain.Common;
using NexusCRM.Domain.Enums;
namespace NexusCRM.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get;  set; } = string.Empty;
    public string Slug { get; set; } = string.Empty; // Unique identfier for the company, used in URLs
    public string? LogoUrl { get; set; } 
    public string? Industry { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public ICollection<User> Users { get; set; } = new List<User>();
}
