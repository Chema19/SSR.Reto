using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Common.Collection
{
    public class DataCollection<T>
    {
        public bool HasItems
        {
            get
            {
                return Items != null && Items.Any();
            }
        }
        public IEnumerable<T> Items { set; get; }
        public int Total { set; get; }
        public int Page { set; get; }
        public int Pages { set; get; }
    }
}
