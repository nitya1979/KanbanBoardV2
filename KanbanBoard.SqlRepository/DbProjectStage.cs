using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KanbanBoard.SqlRepository
{
    [Table("tblProjectStage")]
    public class DbProjectStage : KanbanEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StageID { get; set; }

        [MaxLength(100)]
        [Required]
        public string StageName { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public DbProject Project {get ; set;}
        
    }
}
