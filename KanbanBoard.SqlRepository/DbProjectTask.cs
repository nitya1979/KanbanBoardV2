
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KanbanBoard.SqlRepository
{
    [Table("tblProjectTask")]
    public class DbProjectTask : KanbanEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        [MaxLength(255)]
        [Required]
        public string Summary { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Required]
        public int StageID { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime CompletionDate { get; set; }
        
        [ForeignKey("StageID")]
        public DbProjectStage Stage { get; set; }
    }
}
