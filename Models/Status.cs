using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public int IdStatus { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
