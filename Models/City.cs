using System;
using System.Collections.Generic;

namespace ООО_Посуда.Models
{
    public partial class City
    {
        public City()
        {
            Pickuppoints = new HashSet<Pickuppoint>();
        }

        public int IdCity { get; set; }
        public string CityName { get; set; } = null!;

        public virtual ICollection<Pickuppoint> Pickuppoints { get; set; }
    }
}
