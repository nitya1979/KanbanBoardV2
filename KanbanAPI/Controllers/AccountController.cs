using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanAPI.ViewModels;
using KanbanBoardCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KanbanAPI.Filters;
using KanbanAPI.Helper;

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

            result = await _userService.Register(model.Email, model.Password);

            if (result.Success)
                return Ok(new ApiOkResponse(null));
            else
                return BadRequest(new ApiBadRequestResponse(result.Errors.ToArray()));


        }

        [AllowAnonymous]
        [HttpGet]
        [Route("validateuser/{userName}")]
        public async Task<IActionResult> ValidateUser(string userName)
        {
            KanbanResult result = await _userService.GetUserDetails(userName);

            if (result.Success)
                return BadRequest(new ApiBadRequestResponse(new string[] { userName + " already exists." } ));
            else
                return Ok();
        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordModel model)
        {
            KanbanResult kanbanResult = new KanbanResult();
           
            var result = await _userService.ChangePassword(this.User.Identity.Name, model.CurrentPassword, model.NewPassword);

            if (result.Success)
            {
                return Ok(new ApiOkResponse(null));
            }
            else
                return BadRequest(new ApiBadRequestResponse(result.Errors.ToArray()));

        }

        [HttpGet]
        [Route("userdetail")]
        public async Task<IActionResult> UserDetail(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
                return BadRequest(KanbanResult.CreateErrorResult(new List<string>() { "Username is not provided." }));

            KanbanResult result = await _userService.GetUserDetails(userName);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        [Route("updatephone")]
        public async Task<IActionResult> UpdateContact([FromBody]string phoneno )
        {
            KanbanResult result = await _userService.GetUserDetails(this.User.Identity.Name);

            if (result.Success)
            {
                UserDetail user = result.Result as UserDetail;

                user.PhoneNo = phoneno;

                result = await _userService.SaveUserDetails(user);

                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            else
                return BadRequest(result);
        }

        public async Task<IActionResult> UpdateProfile([FromBody]UserDetailModel model)
        {
            KanbanResult result = await _userService.GetUserDetails(this.User.Identity.Name);

            if( result.Success)
            {
                UserDetail user = result.Result as UserDetail;

                user.AboutMe = model.AboutMe;

                result = await _userService.SaveUserDetails(user);

                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            else
                return BadRequest(result);
        }

    }
}
