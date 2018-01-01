﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KanbanBoardCore;

namespace KanbanAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        UserService _userService = null;

        public UserController(UserService userService)
        {
            this._userService = userService;
        }
        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> Get(string userName=null)
        {
            List<UserDetail> users = await _userService.GetUsers(userName);
            

            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/User
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
