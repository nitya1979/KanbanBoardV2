using System;
using System.Threading.Tasks;

namespace KanbanBoardCore
{
    public interface IUserRepository
    {
        Task<KanbanResult> Register(string userName, string password);

        Task<KanbanResult> ChangePassword(string userName, string currentPassword, string newPassword);

        Task<KanbanResult> Login(string userName, string password, string grantType);

        Task<KanbanResult> GetUserDetail(string userName);

        Task<KanbanResult> SaveUserDetail(UserDetail userDetail);
    }
}
