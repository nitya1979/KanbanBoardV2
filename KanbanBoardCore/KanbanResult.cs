using System;
using System.Collections.Generic;
using System.Linq;

namespace KanbanBoardCore
{
    public class KanbanResult
    {
        public bool Success
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public List<string> Errors { get; set; } = new List<string>();

        public object Result { get; set; }

        public static KanbanResult CreateOkResult(object result)
        {
            return new KanbanResult { Success = true, Result = result };

        }

        public static KanbanResult CreateErrorResult(List<string> errorMesssages)
        {

            return new KanbanResult { Success = false, Errors = errorMesssages };
        }
    }   
}
