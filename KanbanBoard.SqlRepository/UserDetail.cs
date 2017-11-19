using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoard.SqlRepository
{
    [Table("tblUserDetail")]
    public class UserDetail :KanbanEntity
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
