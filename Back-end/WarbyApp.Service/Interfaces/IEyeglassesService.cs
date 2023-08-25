using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;

namespace WarbyApp.Service.Interfaces
{
    public interface IEyeglassesService
    {
        CreatedResultDto Create(EyeglassesCreateDto createDto);
        void Edit(int id, EyeglassesEditDto editDto);
        EyeglassesGetDto GetById(int id);
        List<EyeglassesGetAllDto> GetAll();
        void Delete(int id);
    }
}
