﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KanbanBoardCore;
using KanbanAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Serilog;

namespace KanbanAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/Users")]
    public class UserController : KanbanController
    {
        UserService _userService = null;


        public UserController(UserService userService)
        {
            this._userService = userService;
        }
        // GET: api/User
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search(string userName=null)
        {
            List<UserDetail> users = await _userService.GetUsers(userName);
            
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet]
        [Route("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest(KanbanResult.CreateErrorResult(new List<string>() { "Username is not provided." }));

            KanbanResult result = await _userService.GetUserDetails(userName);

            if (result.Success)
                return Ok(result.Result);
            else
                return BadRequest(result.Errors.ToArray()) ;
        }
        
        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserDetailModel model)
        {
            Log.Information("api/User/Post");
            var userDetail = Mapper.Map<UserDetail>(model);
            userDetail.UserName = User.Identity.Name;

            var result = await _userService.SaveUserDetails(userDetail);

            return this.GetResult(result);

        }
                
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
