using System;
namespace KanbanBoardCore
{
    public class ProjectOverview
    {
        public int ProjectID
        {
            get;
            set;
        }

        public string ProjectName
        {
            get;
            set;
        }

        public int BackLogCount
        {
            get;
            set;
        }

        public int InProgress
        {
            get;
            set;
        }

        public int Completed
        {
            get;
            set;
        }
    }
}
