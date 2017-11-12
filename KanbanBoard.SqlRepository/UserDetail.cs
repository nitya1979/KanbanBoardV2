using System;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.SqlRepository
{
    public class UserDetail
    {
        [Key]
        public string UserName
        {
            get;
            set;
        }
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
