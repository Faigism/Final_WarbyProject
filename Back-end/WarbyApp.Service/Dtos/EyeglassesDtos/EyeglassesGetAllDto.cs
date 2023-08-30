using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;

namespace WarbyApp.Service.Dtos.EyeglassesDtos
{
    public class EyeglassesGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ImageUrl { get; set; }
        public List<EyeglassesGetAllColorDto> Colors { get; set; }
    }
    public class EyeglassesGetAllColorDto
    {
        public int ColorId { get; set; }
        public EyeColorAllDto Color { get; set; }
        public class EyeColorAllDto
        {
            public string ColorName { get; set; }
            public string ColorImage { get; set; }
        }
    }
}
