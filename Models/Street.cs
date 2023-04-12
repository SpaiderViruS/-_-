using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class Street
    {
        public Street()
        {
            Pickuppoints = new HashSet<Pickuppoint>();
        }

        public int IdStreet { get; set; }
        public string StreetName { get; set; } = null!;

        public virtual ICollection<Pickuppoint> Pickuppoints { get; set; }
    }
}
