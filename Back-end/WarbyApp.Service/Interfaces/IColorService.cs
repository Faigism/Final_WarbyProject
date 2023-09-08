using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Service.Dtos.ColorDtos;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.SunglassesDtos;

namespace WarbyApp.Service.Interfaces
{
    public interface IColorService
    {
        CreatedResultDto Create(ColorCreateDto createDto);
        void Edit(int id, ColorEditDto editDto);
        ColorGetDto GetById(int id);
        List<ColorGetAllDto> GetAll();
        void Delete(int id);
    }
}
