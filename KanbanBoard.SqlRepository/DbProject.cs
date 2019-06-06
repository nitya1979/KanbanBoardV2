using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KanbanBoard.SqlRepository
{
    [Table("tblProject")]
    public class DbProject : KanbanEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProjectName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int QuadrantID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public List<DbProjectStage> Stages { get; set; }

//        [ForeignKey("QuadrantID")]
//        public DbQuadrant Quadrant { get; set; }
    }
}
