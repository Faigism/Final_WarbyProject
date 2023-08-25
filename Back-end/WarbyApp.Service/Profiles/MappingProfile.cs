using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;

namespace WarbyApp.Service.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Eyeglasses, CreatedResultDto>();
            CreateMap<EyeglassesCreateDto, Eyeglasses>();
            CreateMap<Eyeglasses, EyeglassesGetDto>();
            CreateMap<Eyeglasses, EyeglassesGetAllDto>();
        }
    }
}
