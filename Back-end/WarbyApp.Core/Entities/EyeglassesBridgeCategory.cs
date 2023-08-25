using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesBridgeCategory
    {
        public int EyeglassesId { get; set; }
        public int BridgeCategoryId { get; set; }
        public BridgeCategory BridgeCategory { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
    }
}
