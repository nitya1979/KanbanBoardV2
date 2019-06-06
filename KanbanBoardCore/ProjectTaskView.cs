using System;
namespace KanbanBoardCore
{
    public class ProjectTaskView : ProjectTask
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public string StageName { get; set; }

        public string PriorityName { get; set; }
    }
}
