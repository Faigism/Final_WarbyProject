using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;
using WarbyApp.Service.Dtos.SunglassesDtos;

namespace WarbyApp.Service.Interfaces
{
    public interface ISunglassesService
    {
        CreatedResultDto Create(SunglassesCreateDto createDto);
        void Edit(int id, SunglassesEditDto editDto);
        SunglassesGetDto GetById(int id);
        List<SunglassesGetAllDto> GetAll();
        PaginatedListDto<SunglassesGetPaginatedListItemDto> GetAllPaginated(int page);
        void Delete(int id);
    }
}
