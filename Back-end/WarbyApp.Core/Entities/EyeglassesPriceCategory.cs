using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesPriceCategory
    {
        public int EyeglassesId { get; set; }
        public int PriceCategoryId { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
        public PriceCategory PriceCategory { get; set; }
    }
}
