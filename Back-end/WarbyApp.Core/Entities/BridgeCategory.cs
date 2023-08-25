using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class BridgeCategory:BaseEntity
    {
        public string Name { get; set; }
        public List<EyeglassesBridgeCategory> EyeglassesBridgeCategories { get; set; }
    }
}
