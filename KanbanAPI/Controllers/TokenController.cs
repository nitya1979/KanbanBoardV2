using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KanbanBoardCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KanbanAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private UserService _userService;


        public TokenController(UserService userService)
        {
            this._userService = userService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get(string username, string password, string grant_type)
        {
            var result = await _userService.Login(username, password, grant_type);

            if (result.Success)
			{

					var claims = new[]
					{
                        new Claim( JwtRegisteredClaimNames.Sub, username),
                        new Claim( JwtRegisteredClaimNames.UniqueName, username),
                        new Claim( JwtRegisteredClaimNames.GivenName, username),
						new Claim( JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
					};

					var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretesecretesecretesecretesecretesecrete"));
					var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken( issuer: "test",
                                                     audience: "test",
                                                     claims: claims,
                            						  expires: DateTime.Now.AddDays(15),
                            						  signingCredentials: creds);
                    
                    return Ok(new { access_token = new JwtSecurityTokenHandler().WriteToken(token), expires_on=DateTime.Now.AddDays(15) });

				
			}


			return BadRequest(result.Errors);
        }


    }
}
