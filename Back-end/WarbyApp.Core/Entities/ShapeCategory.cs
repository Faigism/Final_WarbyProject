using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class ShapeCategory:BaseEntity
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public List<EyeglassesShapeCategory> EyeglassesShapeCategories { get; set; }
    }
}
