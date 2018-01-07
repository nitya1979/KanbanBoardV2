using System;
using System.Collections.Generic;
using System.Text;

namespace KanbanBoardCore
{
    public class CoreObject
    {

        protected DateTime? _modifyDate = null;

        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifyDate
        {
            get
            {
                if (_modifyDate != null && _modifyDate.Value == DateTime.MinValue)
                    return null;

                return _modifyDate;
            }
            set { _modifyDate = value; }
        }
    }
}
