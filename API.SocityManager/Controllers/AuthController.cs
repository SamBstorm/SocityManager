using API.SocityManager.Models;
using Common.SocityManager.Repositories;
using B = BLL.SocityManager.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.SocityManager.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.SocityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository<B.User> _repo;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config, IUserRepository<User> repo)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost]
        public ActionResult Authenticate(UserCheck user)
        {
            try
            {
                User u_db = _repo.CheckPassword(user.Email, user.Password);
                if (u_db is null) throw new Exception();
                Claim[] claims = new[] {
                    //new Claim(JwtRegisteredClaimNames.Sub,_config.GetSection("Jwt").GetSection("Subject").Value),
                    new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    new Claim("Email",u_db.Email),
                    new Claim("UserId",u_db.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires : DateTime.UtcNow.AddMinutes(3),
                    signingCredentials : signIn
                    );
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
