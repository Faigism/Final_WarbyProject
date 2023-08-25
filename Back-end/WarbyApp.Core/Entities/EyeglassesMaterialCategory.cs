using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesMaterialCategory
    {
        public int EyeglassesId { get; set; }
        public int MaterialCategoryId { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
        public MaterialCategory MaterialCategory { get; set; }
    }
}
