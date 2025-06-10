using System.Security.Claims;

namespace ProjectName.Application.Core.Interfaces;

public interface IJwtService
{
    Task<string> GenerateJwtTokenAsync(IEnumerable<Claim> claims);
}