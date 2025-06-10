namespace ProjectName.Application.Core.Config;
public class JwtConfig
{
    public const string SettingKey = nameof(JwtConfig);
    public required string Secret { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public int ExpiryMinutes { get; set; }
}