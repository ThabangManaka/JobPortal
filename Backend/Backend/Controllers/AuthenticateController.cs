using AutoMapper;
using Backend.Helpers;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Text;

namespace Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;

        public AuthenticateController(IUnitOfWork uow, IMapper mapper, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            this.configuration = configuration;
            this.uow = uow;
            this.mapper = mapper;
            _appSettings = appSettings.Value;

        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginReqDto loginReq)
        {
            var user = await uow.UserRepository.Authenticate(loginReq.Username, loginReq.Password);

            if (user == null)
            {

              return Unauthorized();
            }

            var userdetails = uow.UserRepository.GetUserDetailsbyCredentials(loginReq.Username);

            var loginRes = new LoginResDto();
            loginRes.Username = user.Username;
            //UserType
            loginRes.UserId = user.UserId;
            loginRes.Token = CreateJWT(user);
            return Ok(loginRes);
        }



        private string CreateJWT(Users user)
        {
            //var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
               .GetBytes(_appSettings.Secret));

            double tokenExpiryTime = Convert.ToDouble(_appSettings.ExpireTime);
            var claims = new Claim[] {
                    new Claim(ClaimTypes.Name,user.Username),
                    //new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                };

            var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
