using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class SunglassesColor
    {
        public int SunglassesId { get; set; }
        public int ColorId { get; set; }
        public Sunglasses Sunglasses { get; set; }
        public Color Color { get; set; }
    }
}
