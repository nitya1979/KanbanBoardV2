using System;
using System.Collections.Generic;
using System.Text;

namespace KanbanBoardCore
{
    public class ProjectTask : CoreObject
    {
        public int TaskID { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public Project  Project { get; set; }

        public ProjectStage Stage { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public DateTime dateTime { get; set; }
    }
}
