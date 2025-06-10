using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProjectName.Application.Core.Config;
using ProjectName.Application.Core.Interfaces;

namespace ProjectName.Application.Services;

public sealed class JwtService(JwtConfig config) : IJwtService
{
    public Task<string> GenerateJwtTokenAsync(IEnumerable<Claim> claims)
    {
        var credentials = GetSigningCertificate();
        var token = GenerateEncryptedToken(credentials, claims);
        return Task.FromResult(token);
    }

    private string GenerateEncryptedToken(SigningCredentials credentials, IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken
        (
            config.Issuer,
            config.Audience,
            expires: DateTime.UtcNow.AddMinutes(config.ExpiryMinutes),
            signingCredentials: credentials,
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private SigningCredentials GetSigningCertificate()
    {
        var secret = Encoding.UTF8.GetBytes(config.Secret);
        var key = new SymmetricSecurityKey(secret);
        var result = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        return result;
    }
}