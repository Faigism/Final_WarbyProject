using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class EyeglassesImage:BaseEntity
    {
        public int ColorImageId { get; set; }
        public string ImageName { get; set; }
        public ColorImage ColorImage { get; set; }
    }
}
