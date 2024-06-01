namespace Services.Managers.Implementations
{
    using Services.Entities;
    using Services.Managers.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    using System.Text;

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetTokenAsync(UserEntity user)
        {
            var secret = _configuration["Jwt:Secret"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var subject = _configuration["Jwt:Subject"];
            var durationInMinutes = Convert.ToInt32(_configuration["Jwt:DurationInMinutes"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var claims = GenerateClaims(user, subject);

            var tokenDescriptor = CreateTokenDescriptor(claims, issuer, audience, durationInMinutes, key);

            var generatedToken = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(generatedToken);

            return tokenString;

        }

        #region Private Methods

        private static ClaimsIdentity GenerateClaims(UserEntity user, string subject)
        {
            return new ClaimsIdentity(new[]
            {
            new Claim("Id", user.UserId.ToString()),
            new Claim("Role", user.RoleId.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, subject)
        });
        }

        private static SecurityTokenDescriptor CreateTokenDescriptor(
            ClaimsIdentity claims,
            string issuer,
            string audience,
            int durationInMinutes,
            byte[] key)
        {
            return new SecurityTokenDescriptor
            {
                Subject = claims,
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.UtcNow.AddMinutes(durationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
        }

        #endregion
    }
}
