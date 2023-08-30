using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Core.Repositories;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.SunglassesDtos;
using WarbyApp.Service.Exceptions;
using WarbyApp.Service.Helpers;
using WarbyApp.Service.Interfaces;
using static WarbyApp.Service.Dtos.SunglassesDtos.SunglassesGetAllColorDto;

namespace WarbyApp.Service.Implementations
{
    public class SunglassesService:ISunglassesService
    {
        private readonly ISunglassesRepository _sunglassesRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _rootPath;

        public SunglassesService(ISunglassesRepository sunglassesRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _sunglassesRepository = sunglassesRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
        }

        public CreatedResultDto Create(SunglassesCreateDto createDto)
        {
            if (_sunglassesRepository.IsExist(x => x.Name == createDto.Name))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", $"Name already take");
            var entity = _mapper.Map<Sunglasses>(createDto);
            entity.ImageName = FileManager.Save(createDto.ImageName, _rootPath, "uploads/mainimages/sunglasses");
            _sunglassesRepository.Add(entity);
            _sunglassesRepository.Commit();

            return _mapper.Map<CreatedResultDto>(entity);
        }

        public void Edit(int id, SunglassesEditDto editDto)
        {
            var entity = _sunglassesRepository.Get(x => x.Id == id);
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id: {id}");
            if (entity.Name != editDto.Name && _sunglassesRepository.IsExist(x => x.Name == editDto.Name))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", "Name already exists");
            entity.Name = editDto.Name;
            entity.Material = editDto.Material;
            entity.CostPrice = editDto.CostPrice;
            entity.SalePrice = editDto.SalePrice;
            entity.DiscountPercent = editDto.DiscountPercent;
            entity.ModifiedAt = DateTime.UtcNow;
            string existMainImages = null;

            if (editDto.ImageName != null)
            {
                existMainImages = entity.ImageName;
                entity.ImageName = FileManager.Save(editDto.ImageName, _rootPath, "uploads/mainimages/sunglasses");
            }
            _sunglassesRepository.Commit();
            if (existMainImages != null)
                FileManager.Delete(_rootPath, "uploads/mainimages/sunglasses", existMainImages);
        }
        public List<SunglassesGetAllDto> GetAll()
        {
            var entities = _sunglassesRepository.GetQueryable(x => true, "Colors.Color").ToList();
            var getallDto = _mapper.Map<List<SunglassesGetAllDto>>(entities);
            var baseUrl = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);
            for (int i = 0; i < getallDto.Count; i++)
            {
                getallDto[i].ImageUrl = baseUrl + "/uploads/mainimages/sunglasses/" + entities[i].ImageName;
                var dto = getallDto[i];
                var entity = entities.FirstOrDefault(e => e.Id == dto.Id);

                if (entity != null && entity.Colors != null)
                {
                    dto.Colors = entity.Colors.Select(c =>
                    {
                        if (c != null && c.Color != null)
                        {
                            return new SunglassesGetAllColorDto
                            {
                                ColorId = c.ColorId,
                                Color = new ColorDto
                                {
                                    ColorName = c.Color.ColorName,
                                    ColorImage = c.Color.ColorImage
                                }
                            };
                        }
                        else
                        {
                            return new SunglassesGetAllColorDto
                            {
                                ColorId = c.ColorId,
                                Color = new ColorDto
                                {
                                    ColorName = "Not Color Name",
                                    ColorImage = "Not Color Image"
                                }
                            };
                        }
                    }).ToList();
                }
            }
            return getallDto;
        }

        public SunglassesGetDto GetById(int id)
        {
            var entity = _sunglassesRepository.Get(x => x.Id == id, "Colors.Color");
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id:{id}");
            var getdto = _mapper.Map<SunglassesGetDto>(entity);
            var baseUrl = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);
            getdto.ImageUrl = baseUrl + "/uploads/mainimages/sunglasses/" + entity.ImageName;
            if (entity.Colors != null)
            {
                getdto.Colors = entity.Colors.Select(c =>
                {
                    return new SunglassesGetColorDto
                    {
                        ColorId = c.ColorId,
                        Color = new SunglassesGetColorDto.ColorGetDto
                        {
                            ColorName = c.Color.ColorName,
                            ColorImage = c.Color.ColorImage
                        }
                    };
                }).ToList();
            }
            else
            {
                getdto.Colors = new List<SunglassesGetColorDto>();
            }
            return getdto;
        }
        public void Delete(int id)
        {
            var entity = _sunglassesRepository.Get(x => x.Id == id);
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id: {id}");
            _sunglassesRepository.Delete(entity);
            _sunglassesRepository.Commit();
        }
    }
}
