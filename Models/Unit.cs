using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }

        public int Idunit { get; set; }
        public string? UnitName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
