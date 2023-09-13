using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Service.Dtos.ColorDtos;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;
using WarbyApp.Service.Dtos.SunglassesDtos;

namespace WarbyApp.Service.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile(IHttpContextAccessor _httpContextAccessor)
        {
            var baseUrl = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);

            CreateMap<Eyeglasses, CreatedResultDto>();
            CreateMap<EyeglassesCreateDto, EyeglassesCreateColorNames>();
            CreateMap<EyeglassesCreateDto, Eyeglasses>()
                .ForMember(x => x.Colors, opt => opt.MapFrom(src => new List<EyeglassesColor>
                {
                    new EyeglassesColor
                    {
                        ColorId = src.Colors.ColorId
                    }
                }));
            CreateMap<Eyeglasses, EyeglassesGetDto>()
                .ForMember(x => x.ImageUrl, m => m.MapFrom(s => baseUrl + "/uploads/mainimages/eyeglasses/" + s.ImageName))
                .ForMember(x => x.Colors, a => a.MapFrom(src =>
                src.Colors.Select(c => new EyeglassesGetColorDto
                {
                    ColorId = c.ColorId,
                    Color = new EyeglassesGetColorDto.EyeColorGetDto
                    {
                        ColorName = c.Color.ColorName,
                        ColorImage = baseUrl + "/uploads/colorimages/" + c.Color.ColorImage
                    }
                }).ToList()));

            CreateMap<EyeglassesColor, EyeglassesGetColorDto>()
                .ForMember(c => c.Color, opt => opt.MapFrom(src => new EyeglassesGetColorDto.EyeColorGetDto
                {
                    ColorName = src.Color.ColorName,
                    ColorImage = src.Color.ColorImage
                }));
            CreateMap<Eyeglasses, EyeglassesGetAllDto>()
                .ForMember(x => x.ImageUrl, m => m.MapFrom(s => baseUrl + "/uploads/mainimages/eyeglasses/" + s.ImageName))
                .ForMember(x => x.Colors, a => a.MapFrom(src =>
                src.Colors.Select(c => new EyeglassesGetAllColorDto
                {
                    ColorId = c.ColorId,
                    Color = new EyeglassesGetAllColorDto.EyeColorAllDto
                    {
                        ColorName = c.Color.ColorName,
                        ColorImage = baseUrl + "/uploads/colorimages/" + c.Color.ColorImage
                    }
                }).ToList()));
            CreateMap<EyeglassesColor, EyeglassesGetAllColorDto>()
                .ForMember(c => c.Color, opt => opt.MapFrom(src => new EyeglassesGetAllColorDto.EyeColorAllDto
                {
                    ColorName = src.Color.ColorName,
                    ColorImage = src.Color.ColorImage
                }));
            CreateMap<Eyeglasses, EyeglassesGetPaginatedListItemDto>()
                .ForMember(x => x.ImageUrl, m => m.MapFrom(s => baseUrl + "/uploads/mainimages/eyeglasses/" + s.ImageName));

            CreateMap<Sunglasses, CreatedResultDto>();
            CreateMap<SunglassesCreateDto, Sunglasses>();
            CreateMap<Sunglasses, SunglassesGetDto>()
                .ForMember(x => x.ImageUrl, m => m.MapFrom(s => baseUrl + "/uploads/mainimages/sunglasses/" + s.ImageName))
                .ForMember(x => x.Colors, a => a.MapFrom(src =>
                src.Colors.Select(c => new SunglassesGetColorDto
                {
                    ColorId = c.ColorId,
                    Color = new SunglassesGetColorDto.ColorGetDto
                    {
                        ColorName = c.Color.ColorName,
                        ColorImage = baseUrl + "/uploads/colorimages/" + c.Color.ColorImage
                    }
                }).ToList()));
            CreateMap<SunglassesColor, SunglassesGetColorDto>()
                .ForMember(c => c.Color, opt => opt.MapFrom(src => new SunglassesGetColorDto.ColorGetDto
                 {
                     ColorName = src.Color.ColorName,
                     ColorImage = src.Color.ColorImage
                 }));
            CreateMap<Sunglasses, SunglassesGetAllDto>()
                .ForMember(x => x.ImageUrl, m => m.MapFrom(s => baseUrl + "/uploads/mainimages/sunglasses/" + s.ImageName))
                .ForMember(x => x.Colors, a => a.MapFrom(src =>
                src.Colors.Select(c => new SunglassesGetAllColorDto
                {
                    ColorId = c.ColorId,
                    Color = new SunglassesGetAllColorDto.ColorDto
                    {
                        ColorName = c.Color.ColorName,
                        ColorImage = baseUrl + "/uploads/colorimages/" + c.Color.ColorImage
                    }
                }).ToList()));
            CreateMap<SunglassesColor, SunglassesGetAllColorDto>()
                .ForMember(c => c.Color, opt => opt.MapFrom(src => new SunglassesGetAllColorDto.ColorDto
                {
                    ColorName = src.Color.ColorName,
                    ColorImage = src.Color.ColorImage
                }));
            CreateMap<Sunglasses, SunglassesGetPaginatedListItemDto>();

            CreateMap<Color, CreatedResultDto>();
            CreateMap<ColorCreateDto, Color>();
            CreateMap<Color, ColorGetAllDto>()
                .ForMember(x => x.ColorImage, m => m.MapFrom(s => baseUrl + "/uploads/colorimages/" + s.ColorImage));
            CreateMap<Color, ColorGetDto>()
                .ForMember(x => x.ColorImage, m => m.MapFrom(s => baseUrl + "/uploads/colorimages/" + s.ColorImage));
            CreateMap<Color, ColorGetPaginatedListItemDto>()
                .ForMember(x => x.ColorImage, m => m.MapFrom(s => baseUrl + "/uploads/colorimages/" + s.ColorImage));
        }
    }
}
