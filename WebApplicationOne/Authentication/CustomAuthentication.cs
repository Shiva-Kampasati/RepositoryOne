using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationOne.Data;
using WebApplicationOne.Model;


namespace WebApplicationOne.Authentication
{
    public class CustomAuthentication
    {
        private JwtOptions _jwtOptions;
        private AppDbContext _context;
        public CustomAuthentication(IOptions<JwtOptions> jwtOptions, AppDbContext context)
        {
            _jwtOptions = jwtOptions.Value;
            _context = context;
        }

        public async Task<string> Validate(string username, string password)
        {
            User user =  _context.User.Where(x => x.Email.ToLower() == username.ToLower()).FirstOrDefault();
            if (user != null)
            {
                var claims = new[]
             {
                new Claim("username",username),
                new Claim("Password",password)
            };

                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                     issuer: _jwtOptions.Issuer,
                     audience: _jwtOptions.Audience,
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret)), SecurityAlgorithms.HmacSha256)
                     );

                return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
