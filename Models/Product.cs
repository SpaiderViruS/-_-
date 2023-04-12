using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class Product
    {
        public Product()
        {
            Orderproducts = new HashSet<Orderproduct>();
        }

        public string ProductArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int ProductUnitId { get; set; }
        public string ProductPhoto { get; set; } = null!;
        public decimal ProductCost { get; set; }
        public sbyte? ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public double ProductMaxDiscount { get; set; }
        public int ProductSupplierId { get; set; }
        public int ProductManufacturerId { get; set; }
        public int ProductCategoryId { get; set; }

        public virtual Category ProductCategory { get; set; } = null!;
        public virtual Manufacture ProductManufacturer { get; set; } = null!;
        public virtual Supplier ProductSupplier { get; set; } = null!;
        public virtual Unit ProductUnit { get; set; } = null!;
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
