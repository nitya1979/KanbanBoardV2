using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KanbanBoard.SqlRepository
{
    public class KanbanEntity
    {
        [MaxLength(150)]
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [MaxLength(150)]
        public DateTime ModifyDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
