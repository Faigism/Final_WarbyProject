using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesWidthCategory
    {
        public int EyeglassesId { get; set; }
        public int WidthCategoryId { get; set; }
        public WidthCategory WidthCategory { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
    }
}
