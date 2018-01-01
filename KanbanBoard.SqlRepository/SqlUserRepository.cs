using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanBoardCore;
using Microsoft.AspNetCore.Identity;
using core = KanbanBoardCore;
using AutoMapper;

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

        public async Task<KanbanResult> GetUserDetail(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user != null)
            {

                core.UserDetail userDetail = new core.UserDetail
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNo = user.PhoneNumber,
                    ImageUrl = user.ImageUrl,
                    AboutMe = user.AboutMe
                };

                return KanbanResult.CreateOkResult(userDetail);
            }
            else
                return KanbanResult.CreateErrorResult(new List<string> { "User not found" });
            
        }

        public Task<List<UserDetail>> GetUsers(string partialUserName)
        {
            return Task.Factory.StartNew(() =>
            {
                IList<UserEntity> users = null;

                if (!string.IsNullOrEmpty(partialUserName))
                    users = userManager.Users.ToList();
                else
                    users = userManager.Users.Where(u => u.UserName.Contains(partialUserName)).ToList();

                List<UserDetail> userDetails = new List<UserDetail>();

                foreach (var usr in users)
                {
                    userDetails.Add(Mapper.Map<UserDetail>(usr));
                }

                return userDetails;
            });
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

        public async Task<KanbanResult> SaveUserDetail(UserDetail userDetail)
        {
            var user = await userManager.FindByNameAsync(userDetail.UserName);

            if( user != null)
            {
                //user.Email = userDetail.Email,
                user.PhoneNumber = userDetail.PhoneNo;
                user.ImageUrl = userDetail.ImageUrl;
                user.AboutMe = userDetail.AboutMe;

                IdentityResult result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                    return KanbanResult.CreateOkResult(null);
                else
                    return KanbanResult.CreateErrorResult(result.Errors.Select(e => e.Description).ToList());
            }
            else
            {
                return KanbanResult.CreateErrorResult(new List<string> { "User '" + userDetail.UserName + "' not found" });
            }
        }
    }
}
