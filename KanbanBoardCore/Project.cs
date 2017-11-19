using System;
using System.Collections.Generic;
using System.Text;

namespace KanbanBoardCore
{
    public class Project : CoreObject
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletionDate { get; set; }

    }
}
