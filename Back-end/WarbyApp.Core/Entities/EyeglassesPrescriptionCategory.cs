using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesPrescriptionCategory
    {
        public int EyeglassesId { get; set; }
        public int PrescriptionCategoryId { get; set; }
        public PrescriptionCategory PrescriptionCategory { get; set; }
        public Eyeglasses Eyeglasses { get; set; }
    }
}
