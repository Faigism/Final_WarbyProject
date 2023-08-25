using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class ColorCategory:BaseEntity
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public List<EyeglassesColorCategory> EyeglassesColorCategories { get; set; }
    }
}
