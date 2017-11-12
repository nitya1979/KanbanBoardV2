using System;
using System.Threading.Tasks;

namespace KanbanBoardCore
{
    public class UserService
    {
        IUserRepository _userRepository = null;


        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public Task<KanbanResult> Register(string userName, string password)
        {
            return _userRepository.Register(userName, password);
        }

        public Task<KanbanResult> ChangePassword(string userName, string currentPassword, string newPassword)
        {
            return _userRepository.ChangePassword(userName, currentPassword, newPassword);

        }

        public Task<KanbanResult> Login(string userName, string password, string grantType)
        {
            return _userRepository.Login(userName, password, grantType);
        }
    }
}
