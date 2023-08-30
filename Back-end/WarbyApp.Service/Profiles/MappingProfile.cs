using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;
using WarbyApp.Service.Dtos.SunglassesDtos;

namespace WarbyApp.Service.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Eyeglasses, CreatedResultDto>();
            CreateMap<EyeglassesCreateDto, Eyeglasses>();
            CreateMap<Eyeglasses, EyeglassesGetDto>();
            CreateMap<EyeglassesColor, EyeglassesGetColorDto>()
                .ForMember(c => c.Color, opt => opt.MapFrom(src => new EyeglassesGetColorDto.EyeColorGetDto
                {
                    ColorName = src.Color.ColorName,
                    ColorImage = src.Color.ColorImage
                }));
            CreateMap<Eyeglasses, EyeglassesGetAllDto>();
            CreateMap<EyeglassesColor, EyeglassesGetAllColorDto>()
                .ForMember(c => c.Color, opt => opt.MapFrom(src => new EyeglassesGetAllColorDto.EyeColorAllDto
                {
                    ColorName = src.Color.ColorName,
                    ColorImage = src.Color.ColorImage
                }));

            CreateMap<Sunglasses, CreatedResultDto>();
            CreateMap<SunglassesCreateDto, Sunglasses>();
            CreateMap<Sunglasses, SunglassesGetDto>();
            CreateMap<SunglassesColor, SunglassesGetColorDto>()
                .ForMember(c => c.Color, opt => opt.MapFrom(src => new SunglassesGetColorDto.ColorGetDto
                 {
                     ColorName = src.Color.ColorName,
                     ColorImage = src.Color.ColorImage
                 }));

            CreateMap<Sunglasses, SunglassesGetAllDto>();
            CreateMap<SunglassesColor, SunglassesGetAllColorDto>()
                .ForMember(c => c.Color, opt => opt.MapFrom(src => new SunglassesGetAllColorDto.ColorDto
                {
                    ColorName = src.Color.ColorName,
                    ColorImage = src.Color.ColorImage
                }));
        }
    }
}
