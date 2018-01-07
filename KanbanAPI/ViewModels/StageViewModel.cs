using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.ViewModels
{
    public class StageViewModel
    {
        public int StageID { get; set; }

        [Required(ErrorMessage = "Stage name is required.")]
        public string StageName { get; set; }

        [Required(ErrorMessage = "Order is required")]
        public int Order { get; set; }

    }
}
