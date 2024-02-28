using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using PROJECT_PRN231.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PROJECT_PRN231.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings _applicationSettings;
        private readonly ExamSystemContext _examSystemContext;
        public AuthController(IOptions<AppSettings> applicationSettings, ExamSystemContext examSystemContext)
        {
            _applicationSettings = applicationSettings.Value;
            _examSystemContext = examSystemContext;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            var user = _examSystemContext.Users.Where(x => x.Username == login.Username).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("UserName or password incorrect");
            }
            var match = CheckPassword(login.Password, user);
            if (!match)
            {
                return BadRequest("UserName or password incorrect");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Username), new Claim(ClaimTypes.Role, user.Role) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encrypterToken = tokenHandler.WriteToken(token);

            return Ok(new { token = encrypterToken, userName = user.Username });
        }
        [ApiExplorerSettings(IgnoreApi =true)]
        public bool CheckPassword(string password, User user)
        {
            bool result;
            using (HMACSHA512? hmac = new HMACSHA512(user.PasswordSalt))
            {
                var compute = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                result = compute.SequenceEqual(user.PasswordHash);
            }
            return result;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] Register registerModel)
        {
            var user = new User { Username = registerModel.Username, Role = registerModel.Role};
            if (registerModel.ConfirmPassword == registerModel.Password)
            {
                using (HMACSHA512? hmac = new HMACSHA512())
                {
                    user.PasswordSalt = hmac.Key;
                    user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(registerModel.Password));
                }
            }
            else
            {
                return BadRequest("Password dont match");
            }
            _examSystemContext.Users.Add(user);
            _examSystemContext.SaveChanges();
            return Ok(user);
        }
    }
}
