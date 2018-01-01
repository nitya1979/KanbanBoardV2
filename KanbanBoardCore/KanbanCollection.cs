using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KanbanBoardCore
{
    public class KanbanCollection<T> 
    {
        IList<T> items = null;

        public int Count
        {
            get; set;
        }
        /// <summary>
        /// Constructor to return list which holds all items and keep information of total number of items,
        /// usefull when pagination is appied
        /// </summary>
        /// <param name="items">List for itmes for a page.</param>
        /// <param name="totalCount">Total count for result</param>
        public KanbanCollection(IList<T> items, int totalCount)
        {
            this.items = items;
            this.Count = totalCount;

        }

        public IList<T> Items
        {
            get { return this.items; }
        }
    }
}
