using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApp.Services
{

    /// <summary>
    ///  JWT authentication options
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        ///  Jwt secret string
        /// </summary>
        public string Secret { get; set; }
    }

    public class JwtService
    {
        /// <summary>
        ///  Options loaded in dependency injection
        /// </summary>
        private readonly JwtOptions _options;

        /// <summary>
        ///  Constructs JwtService by providing options
        /// </summary>
        /// <param name="jwtOptions">JWT options</param>
        public JwtService(IOptions<JwtOptions> jwtOptions)
        {
            _options = jwtOptions.Value;
        }

        /// <summary>
        ///  Generate JWT
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>JWT in url-encoded base64 format</returns>
        public string Generate(int id)
        {
            SymmetricSecurityKey symKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
            SigningCredentials credentials = new SigningCredentials(symKey, SecurityAlgorithms.HmacSha256Signature);
            JwtHeader header = new JwtHeader(credentials);

            JwtPayload payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
            JwtSecurityToken token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        /// <summary>
        ///  Validate a JWT token
        /// </summary>
        /// <param name="jwt">JWT token string</param>
        /// <returns>Validated JWT token</returns>
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
