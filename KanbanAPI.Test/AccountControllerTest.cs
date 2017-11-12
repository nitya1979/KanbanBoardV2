using System.Security.Claims;
using System.Threading.Tasks;
using KanbanAPI.Controllers;
using KanbanAPI.ViewModels;
using KanbanBoard.SqlRepository;
using KanbanBoardCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace KanbanAPI.Test
{

    public class AccountControllerTest
    {
        AccountController accountController;

        public AccountControllerTest()
        {
            var userStoreMock = new Mock<IUserStore<UserEntity>>();
            var mockUserMgr = new Mock<UserManager<UserEntity>>(userStoreMock.Object,  null, null, null, null, null, null, null, null );
            
            mockUserMgr.Setup(mgr => mgr.CreateAsync(It.IsAny<UserEntity>())).Returns(Task.FromResult(IdentityResult.Success));
            mockUserMgr.Setup(mgr => mgr.ChangePasswordAsync(It.IsAny<UserEntity>(), It.IsAny<string>(), It.IsAny<string>()))
                       .Returns(Task.FromResult(IdentityResult.Success));
            mockUserMgr.Setup(mgr => mgr.FindByNameAsync(It.IsAny<string>()))
                       .Returns(Task.FromResult(new UserEntity { UserName = "nityaprakash@gmail.com" }));
            
            var roleStoreMock = new Mock<IRoleStore<KanbanRoles>>();
            var mockRoleMgr = new Mock<RoleManager<KanbanRoles>>( roleStoreMock.Object, null, null, null, null);



            var sqlUserRepo = new Mock<IUserRepository>();

            var userService = new UserService(sqlUserRepo.Object);

            accountController =  new AccountController(userService);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim( ClaimTypes.Name, "nityaprakash@gamil.com")
            }));

            accountController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
        }

        [Fact]
        public async Task Change_Password_Negative_Test()
        {

            ChangePasswordModel model = new ChangePasswordModel { CurrentPassword = "currentPassowrd", ConfirmPassword = "NewPassword", NewPassword = "abc" };

            var result = await accountController.ChangePassword(model);

            BadRequestObjectResult badResult = Assert.IsType<BadRequestObjectResult>(result);

            KanbanResult kResult = Assert.IsType<KanbanResult>(badResult.Value);

            Assert.Equal(false, kResult.Success);
            Assert.Equal("Confirmed password is not matching", kResult.Errors[0]);
        }

         [Fact]
        public async Task Change_Password_Test()
        {

            ChangePasswordModel model = new ChangePasswordModel { CurrentPassword = "currentPassowrd", ConfirmPassword = "NewPassword", NewPassword = "NewPassword" };

            var result = await accountController.ChangePassword(model);

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);

            KanbanResult kResult = Assert.IsType<KanbanResult>(okResult.Value);

            Assert.Equal(true, kResult.Success);
        }
    }
}
