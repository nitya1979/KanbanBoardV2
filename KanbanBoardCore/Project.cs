using System;
using System.Collections.Generic;
using System.Text;

namespace KanbanBoardCore
{
    public class Project : CoreObject
    {
        private DateTime? _completionDate = null;
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? CompletionDate
        {
            get
            {
                if (_completionDate != null && _completionDate.Value == DateTime.MinValue)
                    return null;
                return _completionDate;
            }

            set
            {
                _completionDate = value;
            }
                
        }

    }
}
