using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;

namespace WarbyApp.Service.Dtos.SunglassesDtos
{
    public class SunglassesGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ImageUrl { get; set; }
        public List<SunglassesGetAllColorDto> Colors { get; set; }
    }
    public class SunglassesGetAllColorDto
    {
        public int ColorId { get; set; }
        public ColorDto Color { get; set; }
        public class ColorDto
        {
            public string ColorName { get; set; }
            public string ColorImage { get; set; }
        }
    }
}
