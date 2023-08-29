using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class Accessories:BaseTrackedEntity
    {
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; } = 0;
        public string Description { get; set; }
        public string Material { get; set; }
        public string ImageName { get; set; }
    }
}
