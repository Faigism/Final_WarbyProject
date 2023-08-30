using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesColor
    {
        public int EyeglassesId { get; set; }
        public int ColorId { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
        public Color Color { get; set; }
    }
}
