using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesShapeCategory
    {
        public int EyeglassesId { get; set; }
        public int ShapeCategoryId { get; set; }
        public ShapeCategory ShapeCategory { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
    }
}
