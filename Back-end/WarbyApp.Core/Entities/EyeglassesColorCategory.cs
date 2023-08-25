using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesColorCategory
    {
        public int EyeglassesId { get; set; }
        public int ColorCategoryId { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
        public ColorCategory ColorCategory { get; set; }
    }
}
