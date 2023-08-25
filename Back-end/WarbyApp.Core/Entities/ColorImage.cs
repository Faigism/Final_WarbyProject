using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class ColorImage:BaseEntity
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public List<EyeglassesImage> EyeglassesImages { get; set; }
    }
}
