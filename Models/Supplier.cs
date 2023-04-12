using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int IdSupplier { get; set; }
        public string SupplierName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
