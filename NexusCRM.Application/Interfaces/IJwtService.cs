using NexusCRM.Domain.Entities;
namespace NexusCRM.Application.Interfaces;

public interface IJwtService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}
