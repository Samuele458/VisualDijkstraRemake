using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApp.Utils
{
    public class JwtService
    {

        private string secureKey = "ssssssssssssssssssssssssssssssssssssssssssssssssssss";

        public string Generate(int id)
        {
            SymmetricSecurityKey symKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            SigningCredentials credentials = new SigningCredentials(symKey, SecurityAlgorithms.HmacSha256Signature);
            JwtHeader header = new JwtHeader(credentials);

            JwtPayload payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
            JwtSecurityToken token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public JwtSecurityToken Verify(string jwt)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secureKey);

            tokenHandler.ValidateToken(jwt, new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validated);

            return (JwtSecurityToken)validated;
        }
    }
}
