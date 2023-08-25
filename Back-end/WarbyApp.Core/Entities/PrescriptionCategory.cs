using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class PrescriptionCategory:BaseEntity
    {
        public string Name { get; set; }
        public List<EyeglassesPrescriptionCategory> EyeglassesPrescriptionCategories { get; set; }
    }
}
