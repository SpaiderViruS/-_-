using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class Manufacture
    {
        public Manufacture()
        {
            Products = new HashSet<Product>();
        }

        public int IdManufactures { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
