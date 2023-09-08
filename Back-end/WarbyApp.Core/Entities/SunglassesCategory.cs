using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class SunglassesCategory
    {
        public int SunglassesId { get; set; }
        public int CategoryId { get; set; }
        public Sunglasses Sunglasses { get; set; }
        public Category Category { get; set; }
    }
}
