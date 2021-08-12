using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApp.Services
{
    public class JwtOptions
    {
        public string Secret { get; set; }
    }

    public class JwtService
    {

        private readonly JwtOptions _options;

        public JwtService(IOptions<JwtOptions> jwtOptions)
        {
            _options = jwtOptions.Value;
        }

        public string Generate(int id)
        {
            SymmetricSecurityKey symKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
            SigningCredentials credentials = new SigningCredentials(symKey, SecurityAlgorithms.HmacSha256Signature);
            JwtHeader header = new JwtHeader(credentials);

            JwtPayload payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
            JwtSecurityToken token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public JwtSecurityToken Verify(string jwt)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Secret);

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
