using Microsoft.IdentityModel.Tokens;
using scavenger_hunt_webapi.Models;
using System.IdentityModel.Tokens.Jwt;

namespace scavenger_hunt_webapi.Services;
public class AuthenticationService
{ 
    private static readonly TimeSpan TokenTime = TimeSpan.FromHours(4);

    private readonly IConfiguration _configuration;
    public AuthenticationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private string GenerateJWT(User user)
    {
        var secret = _configuration["JWT:Secret"];

        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];

        var token = new JwtSecurityToken(issuer, audience);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return "";
    }
}
