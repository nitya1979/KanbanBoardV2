using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KanbanBoardCore
{
    public class ProjectTask : CoreObject
    {
        public int TaskID { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public int PriorityID { get; set; }

        public int StageID { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletionDate { get; set; }

    }
}
