using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using scavenger_hunt_webapi.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace scavenger_hunt_webapi.Services;
public class AuthenticationService
{ 

    private readonly IConfiguration _configuration;
    private readonly HashAlgorithmName algorithmName = HashAlgorithmName.MD5;
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

    public string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(32);
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 32
        ));

        return hashed;
    }
}
