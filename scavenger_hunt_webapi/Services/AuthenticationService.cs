using Microsoft.IdentityModel.Tokens;
using scavenger_hunt_webapi.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace scavenger_hunt_webapi.Services;
public class AuthenticationService
{ 

    private readonly IConfiguration _configuration;
    public AuthenticationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateJWT(User user)
    {
        string secret = _configuration["JWT:Secret"]!;

        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];

        var expirationTime = DateTime.UtcNow.AddHours(4);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString())
            }),
            Expires = expirationTime,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = new JwtSecurityToken(issuer, audience);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}
