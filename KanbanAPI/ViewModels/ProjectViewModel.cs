﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.ViewModels
{
    public class ProjectViewModel
    {

        public int ProjectID { get; set; }

        [Required( AllowEmptyStrings = false, ErrorMessage = "Project Name is required.")]
        public string ProjectName { get; set; }

        [Required( AllowEmptyStrings =false, ErrorMessage = "Project Description is required.")]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        
        public DateTime DueDate { get; set; }
    }
}
