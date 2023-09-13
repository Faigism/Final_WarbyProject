using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarbyApp.Service.Dtos.ColorDtos
{
    public class ColorGetPaginatedListItemDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string ColorImage { get; set; }
    }
}
