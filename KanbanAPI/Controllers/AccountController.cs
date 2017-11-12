using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanAPI.ViewModels;
using KanbanBoardCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KanbanAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        UserService _userService;

		public AccountController(UserService userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            KanbanResult result = null;

            if( model.Password == model.ConfirmPassword)
            {
                result = await _userService.Register(model.Email, model.Password);

                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
                        
            }
            else
            {
                return BadRequest(KanbanResult.CreateErrorResult(new List<string>() { "Confirmed password is not matching" }));
            }

        }



        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordModel model)
        {
            KanbanResult kanbanResult = new KanbanResult();

            if (model.NewPassword == model.ConfirmPassword)
            {
                var result = await _userService.ChangePassword(this.User.Identity.Name, model.CurrentPassword, model.NewPassword);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                    return BadRequest(result);

            }
            else
            {
                
                return BadRequest(KanbanResult.CreateErrorResult(new List<string>{"Confirmed password is not matching"}));

            }


        }
    }
}
