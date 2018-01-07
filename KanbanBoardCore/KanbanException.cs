using System;
using System.Collections.Generic;
using System.Text;

namespace KanbanBoardCore
{
    public class KanbanException : Exception
    {
        public KanbanException()
        {

        }

        public KanbanException(string message):base(message)
        {

        }
    }
}
