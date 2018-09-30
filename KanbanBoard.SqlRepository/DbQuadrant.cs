using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoard.SqlRepository
{
    [Table("tblQuadrant")]
    public class DbQuadrant : KanbanEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuadrantID
        {
            get;
            set;
        }

        [Required]
        [MaxLength(255)]
        public string QuadrantName
        {
            get;
            set;
        }
    }
}
