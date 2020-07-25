using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MenuItemListingWebApi.Models;
using Microsoft.Extensions.Configuration;
using MenuItemListingWebApi.Controllers;

namespace MenuItemListingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

            private IConfiguration _config;

            public TokenController(IConfiguration config)
            {
                _config = config;
            }

            [HttpPost]
            public IActionResult Login([FromBody] AuthenticateUser login)
            {
                IActionResult response = Unauthorized();
                var user = AuthenticateUser(login);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenString });
                }

                return response;
            }

            private string GenerateJSONWebToken(AuthenticateUser userInfo)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            private AuthenticateUser AuthenticateUser(AuthenticateUser login)
            {
                AuthenticateUser user = null;

                //Validate the User Credentials    
                //Demo Purpose, I have Passed HardCoded User Information    
                if (login.Name == "Namit")
                {
                    user = new AuthenticateUser { Name = "Namit", Password = "Namit123*@" };
                }
                return user;
            }
        }
}