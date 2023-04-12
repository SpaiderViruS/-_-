using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class Pickuppoint
    {
        public Pickuppoint()
        {
            Orders = new HashSet<Order>();
        }

        public int IdPickupPoint { get; set; }
        public string Index { get; set; } = null!;
        public int CityId { get; set; }
        public int StreetId { get; set; }
        public string Home { get; set; } = null!;

        public virtual City City { get; set; } = null!;
        public virtual Street Street { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
