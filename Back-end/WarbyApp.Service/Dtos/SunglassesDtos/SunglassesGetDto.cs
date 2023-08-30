using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;

namespace WarbyApp.Service.Dtos.SunglassesDtos
{
    public class SunglassesGetDto
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ImageUrl { get; set; }
        public List<SunglassesGetColorDto> Colors { get; set; }
    }
    public class SunglassesGetColorDto
    {
        public int ColorId { get; set; }
        public ColorGetDto Color { get; set; }
        public class ColorGetDto
        {
            public string ColorName { get; set; }
            public string ColorImage { get; set; }
        }
    }
}
