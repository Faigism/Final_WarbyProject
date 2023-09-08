using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesCategory
    {
        public int EyeglassesId { get; set; }
        public int CategoryId { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
        public Category Category { get; set; }
    }
}
