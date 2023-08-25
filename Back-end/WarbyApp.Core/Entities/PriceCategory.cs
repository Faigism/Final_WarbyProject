using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class PriceCategory:BaseEntity
    {
        public string Name { get; set; }
        public List<EyeglassesPriceCategory> EyeglassesPriceCategories { get; set; }
    }
}
