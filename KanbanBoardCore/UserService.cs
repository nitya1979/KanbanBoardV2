using System;
using System.Collections.Generic;
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

        public Task<KanbanResult> Register(string userName, string email, string password)
        {
            return _userRepository.Register(userName, email, password);
        }

        public Task<KanbanResult> ChangePassword(string userName, string currentPassword, string newPassword)
        {
            return _userRepository.ChangePassword(userName, currentPassword, newPassword);

        }

        public Task<KanbanResult> Login(string userName, string password, string grantType)
        {
            return _userRepository.Login(userName, password, grantType);
        }

        public Task<KanbanResult> GetUserDetails(string userName)
        {
            return _userRepository.GetUserDetail(userName);
        }

        public Task<KanbanResult> SaveUserDetails(UserDetail userDetail)
        {
            return _userRepository.SaveUserDetail(userDetail);
        }

        public Task<List<UserDetail>> GetUsers(string partialUserName = null)
        {
            return  _userRepository.GetUsers(partialUserName);
        }
    }
}
