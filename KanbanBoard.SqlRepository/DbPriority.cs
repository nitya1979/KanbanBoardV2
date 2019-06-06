using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoard.SqlRepository
{
    [Table("tblPriority")]
    public class DbPriority : KanbanEntity
    {
        [Key]
        public int PriorityID { get; set; }

        [MaxLength(125)]
        [Required]
        public string PriorityName { get; set; }
    }
}
