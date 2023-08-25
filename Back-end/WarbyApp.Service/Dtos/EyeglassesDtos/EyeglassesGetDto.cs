using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Service.Dtos.EyeglassesDtos
{
    public class EyeglassesGetDto
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscoutPercent { get; set; }
        public CategoryWidthEyeglassesGetDto WidthCategory { get; set; }
    }
    public class CategoryWidthEyeglassesGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
