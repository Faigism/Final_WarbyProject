using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class FeaturesCategory:BaseEntity
    {
        public string Name { get; set; }
        public List<EyeglassesFeaturesCategory> EyeglassesFeaturesCategories { get; set; }
    }
}
