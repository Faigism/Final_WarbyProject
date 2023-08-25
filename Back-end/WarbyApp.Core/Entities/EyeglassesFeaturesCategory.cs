using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesFeaturesCategory
    {
        public int EyeglassesId { get; set; }
        public int FeaturesCategoryId { get; set; }
        public FeaturesCategory FeaturesCategory { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
    }
}
