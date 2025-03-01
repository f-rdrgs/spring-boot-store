using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotnet_store_test.Tools
{
    public class JWTHandler(IConfiguration config)
    {
        private  JwtSecurityTokenHandler? _handler;

        private  SecurityKey? _securityKey;
        private  readonly IConfiguration _config = config;

        private  JwtSecurityTokenHandler GetHandler() => _handler ??= new JwtSecurityTokenHandler();

        private SecurityKey GetSecurityKey() => _securityKey ??= (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSha256Tok"])));
        public string GenerateToken(Dictionary<string,string> claimsToAdd)
        {
            IEnumerable<Claim> claims = claimsToAdd.Select((kv) => new Claim(kv.Key, kv.Value));

            var claimsId = new ClaimsIdentity(claims);

            return GetHandler().WriteToken(GetHandler().CreateJwtSecurityToken(signingCredentials: new SigningCredentials(GetSecurityKey(), SecurityAlgorithms.HmacSha256),
                issuedAt: DateTime.UnixEpoch,
                subject: claimsId,
                issuer: _config["iss"]));
        }
    }
}
