using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Core.Entities
{
    public class CategoryName:BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public Category Category { get; set; }
    }
}
