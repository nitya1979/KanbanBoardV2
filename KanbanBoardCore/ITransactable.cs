using System;
using System.Collections.Generic;
using System.Text;

namespace KanbanBoardCore
{
    public interface ITransactable 
    {
        void BeginTranaction();

        void CommitTransaction();

        void RollbackTransaction();

    }
}
