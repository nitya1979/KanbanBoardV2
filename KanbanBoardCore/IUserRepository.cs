using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoardCore
{
    public interface IUserRepository
    {
        Task<KanbanResult> Register(string userName, string email, string password );

        Task<KanbanResult> ChangePassword(string userName, string currentPassword, string newPassword);

        Task<KanbanResult> Login(string userName, string password, string grantType);

        Task<KanbanResult> GetUserDetail(string userName);

        Task<KanbanResult> SaveUserDetail(UserDetail userDetail);

		Task<KanbanResult> GetUserByEmail(string email);

        Task<List<UserDetail>> GetUsers(string partialUserName);
    }
}
