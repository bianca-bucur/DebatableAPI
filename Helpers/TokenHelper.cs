using DebatableAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace DebatableAPI.Helpers
{
  public class TokenHelper
  {
    public const string Issuer = "https://localhost:7084";
    public const string Audience = "https://localhost:7084";

    public const string Secret = "OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw==";

    public static string GenerateSecureSecret()
    {
      HMACSHA256 hmac = new HMACSHA256();
      return Convert.ToBase64String(hmac.Key);
    }

    public static string GenerateToken(User user)
    {
      JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
      byte[] key = Convert.FromBase64String(Secret);

      ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
      {
        new Claim(ClaimTypes.NameIdentifier, user.Username.ToString()),
      });

      SigningCredentials signinCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

      SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = claimsIdentity,
        Issuer = Issuer,
        Audience = Audience,
        Expires = DateTime.Now.AddMinutes(15),
        SigningCredentials = signinCredentials
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}
