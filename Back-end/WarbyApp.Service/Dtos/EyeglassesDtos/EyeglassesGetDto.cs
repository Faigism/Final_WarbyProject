using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Service.Dtos.SunglassesDtos;

namespace WarbyApp.Service.Dtos.EyeglassesDtos
{
    public class EyeglassesGetDto
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ImageUrl { get; set; }
        public List<EyeglassesGetColorDto> Colors { get; set; }
    }
    public class EyeglassesGetColorDto
    {
        public int ColorId { get; set; }
        public EyeColorGetDto Color { get; set; }
        public class EyeColorGetDto
        {
            public string ColorName { get; set; }
            public string ColorImage { get; set; }
        }
    }
}
