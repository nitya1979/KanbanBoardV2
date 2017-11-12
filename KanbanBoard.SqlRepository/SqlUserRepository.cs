﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanBoardCore;
using Microsoft.AspNetCore.Identity;

namespace KanbanBoard.SqlRepository
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity> userManager;
        private readonly RoleManager<KanbanRoles> roleManager;
        private readonly SignInManager<UserEntity> signInManager;

        public SqlUserRepository(UserManager<UserEntity> userManager, RoleManager<KanbanRoles> roleManager, SignInManager<UserEntity> signInManager)
        {
            this.userManager = userManager;

            this.roleManager = roleManager;

            this.signInManager = signInManager;
        }

        public async Task<KanbanResult> ChangePassword(string userName, string currentPassword, string newPassword)
        {
            var user = await userManager.FindByNameAsync(userName);

            KanbanResult kanbanResult = new KanbanResult();

            var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (result.Succeeded)
            {
                return KanbanResult.CreateOkResult(string.Empty);
            }
            else
                return KanbanResult.CreateErrorResult(result.Errors.Select(er => er.Description).ToList());

   
        }

        public async Task<KanbanResult> Login(string userName, string password, string grantType)
        {
            var user = await this.userManager.FindByEmailAsync(userName);

            if (user != null)
            {
                var result = await this.signInManager.CheckPasswordSignInAsync(user, password, false);

                if (result.Succeeded)
                    return KanbanResult.CreateOkResult(null);
                else
                    return KanbanResult.CreateErrorResult(new List<string> { "Incorrect password." });
            }
            else
                return KanbanResult.CreateErrorResult(new List<string>() { "User doesn't exist" });
            
        }

        public async Task<KanbanResult> Register(string userName, string password)
        {
            var user = new UserEntity { Email = userName, UserName =userName };


            IdentityResult result = await userManager.CreateAsync(user,password);


            if (result.Succeeded)
            {

                if (!roleManager.RoleExistsAsync("NormalUser").Result)
                {
                    result = await roleManager.CreateAsync(new KanbanRoles { Name = "NormalUser", NormalizedName = "NormalUser" });
                }

                result = await userManager.AddToRoleAsync(user, "NormalUser");

                return KanbanResult.CreateOkResult(null);
            }
            else
                return KanbanResult.CreateErrorResult(result.Errors.Select(e => e.Description).ToList());

        }


    }
}