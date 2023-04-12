using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderproducts = new HashSet<Orderproduct>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public int OrderStatusId { get; set; }
        public int? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderCode { get; set; } = null!;
        public int OrderPickupPointId { get; set; }

        public virtual Pickuppoint OrderPickupPoint { get; set; } = null!;
        public virtual Status OrderStatus { get; set; } = null!;
        public virtual User? User { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
