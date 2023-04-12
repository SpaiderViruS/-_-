using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
