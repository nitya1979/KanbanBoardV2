using KanbanAPI.Controllers;
using KanbanAPI.ViewModels;
using KanbanBoard.SqlRepository;
using KanbanBoardCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
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

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SqlMapperConfiguraiton());
            });

            var sqlUserRepo = new SqlUserRepository(mockUserMgr.Object, mockRoleMgr.Object, null);
            

            var userService = new UserService(sqlUserRepo);
                
            accountController =  new AccountController(userService);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim( ClaimTypes.Name, "nityaprakash@gamil.com")
            }));

            
            accountController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user },
            };


        }

        [Fact]
        public void Change_Password_Negative_Test()
        {

            ChangePasswordModel model = new ChangePasswordModel { CurrentPassword = "currentPassowrd", ConfirmPassword = "NewPassword", NewPassword = "abc" };

            //var result = await accountController.ChangePassword(model);

            //BadRequestObjectResult badResult = Assert.IsType<BadRequestObjectResult>(result);

            //ApiBadRequestResponse kResult = Assert.IsType<ApiBadRequestResponse>(badResult.Value);

            //Assert.Equal(400, kResult.StatusCode);
            //Assert.Equal("Confirm Password is no matching", kResult.Errors.ToArray()[0]);

            ValidationContext vcontex = new ValidationContext(model, null, null);
            var valResult = new List<ValidationResult>();

            Validator.TryValidateObject(model, vcontex, valResult, true);


            //Dictionary<string, object> data = new Dictionary<string, object>();
            //data.Add("CurrentPassword", "e58@t4Ie");
            //data.Add("NewPassword", "abc");
            //data.Add("ConfirmPassword", "xyz");

            //var httpContext = new DefaultHttpContext();
            //var context = new ActionExecutingContext(
            //    new ActionContext
            //    {
            //        HttpContext = httpContext,
            //        RouteData = new RouteData(),
            //        ActionDescriptor = new ActionDescriptor()
            //    },
            //    new List<IFilterMetadata>(),
            //    data,
            //    new Mock<Controller>().Object);

            //var sut = new ApiValidationFilterAttribute();

            ////Act
            //sut.OnActionExecuting(context);
            
            //Act

        }

        // [Fact]
        //public async Task Change_Password_Test()
        //{

        //    ChangePasswordModel model = new ChangePasswordModel { CurrentPassword = "currentPassowrd", ConfirmPassword = "NewPassword", NewPassword = "NewPassword" };

        //    var result = await accountController.ChangePassword(model);

        //    OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);

        //    KanbanResult kResult = Assert.IsType<KanbanResult>(okResult.Value);

        //    Assert.Equal(true, kResult.Success);
        //}
    }
}
