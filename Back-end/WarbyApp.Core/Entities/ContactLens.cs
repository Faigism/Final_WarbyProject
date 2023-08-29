using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class ContactLens:BaseTrackedEntity
    {
        public string Name { get; set; }
        public string Pack { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; } = 0;
        public bool AcuvueBrand { get; set; } = false;
        public bool DailiesBrand { get; set; } = false;
        public bool BiofinityBrand { get; set; } = false;
        public bool AiroptikBrand { get; set; } = false;
        public bool BiotrueBrand { get; set; } = false;
        public bool PrecisionBrand { get; set; } = false;
        public string Description { get; set; }
        public string Material { get; set; }
        public string ImageName { get; set; }
    }
}
