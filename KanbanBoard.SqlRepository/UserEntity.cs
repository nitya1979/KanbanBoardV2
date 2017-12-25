using Microsoft.AspNetCore.Identity;

namespace KanbanBoard.SqlRepository
{

    public class UserEntity : IdentityUser
    {
        public string AboutMe
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }
    }
}
