using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Service.Dtos.SunglassesDtos
{
    public class SunglassesGetPaginatedListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
