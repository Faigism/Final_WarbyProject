using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class Sunglasses:BaseTrackedEntity
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; } = 0;
        public bool? Gender { get; set; }
        public bool AllCategory { get; set; } = true;
        public bool NewarrivalsCategory { get; set; } = false;
        public bool BestsellersCategory { get; set; } = false;
        public bool ClassicmetalsCategory { get; set; } = false;
        public bool AutumnaltonesCategory { get; set; } = false;
        public bool BoldshapesCategory { get; set; } = false;
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string ImageName { get; set; }
        public List<SunglassesColor> Colors { get; set; } = new List<SunglassesColor>();
        public List<SunglassesCategory> Categories { get; set; }
    }
}
