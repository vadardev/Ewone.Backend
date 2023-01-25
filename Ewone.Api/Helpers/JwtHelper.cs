using System.Text;
using Google.Apis.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Ewone.Domain.DataLayer.User;

namespace Ewone.Api.Helpers;

public class JwtHelper
{
    private readonly IConfigurationSection _goolgeSettings;
    private readonly IConfiguration _configuration;

    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;

        _goolgeSettings = configuration.GetSection("GoogleAuthSettings");
    }

    public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken)
    {
        string? clientId = _goolgeSettings.GetSection("clientId").Value;

        if (clientId == null)
        {
            throw new Exception("clientId is null");
        }

        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string>
            {
                clientId
            }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

        return payload;
    }

    public string CreateAccessToken(UserEntity user)
    {
        string? key = _configuration["Token:SecurityKey"];

        if (key == null)
        {
            throw new Exception("SecurityKey is null");
        }

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(key));

        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        int expireInMin = 5;

        if (int.TryParse(_configuration["Token:ExpireInMin"], out var expire))
        {
            expireInMin = expire;
        }

        JwtSecurityToken securityToken = new(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            claims: new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Name, user.Id.ToString()),
            },
            expires: DateTime.UtcNow.AddMinutes(expireInMin),
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials
        );

        JwtSecurityTokenHandler tokenHandler = new();
        return tokenHandler.WriteToken(securityToken);
    }
}