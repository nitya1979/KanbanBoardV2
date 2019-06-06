using System;
using System.ComponentModel.DataAnnotations;

namespace KanbanAPI.ViewModels
{
    public class ProjectTaskViewModel
    {
        public int TaskID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Task summary is required.")]
        public string Summary
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Project ID is required.")]
        public int ProjectID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Priority is required.")]
        public int PriorityID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Stage is required.")]
        public int StageID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Duedate is required.")]
        public DateTime DueDate
        {
            get;
            set;
        }
    }
}
