using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Core.Repositories;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;
using WarbyApp.Service.Exceptions;
using WarbyApp.Service.Helpers;
using WarbyApp.Service.Interfaces;
using static WarbyApp.Service.Dtos.EyeglassesDtos.EyeglassesGetAllColorDto;

namespace WarbyApp.Service.Implementations
{
    public class EyeglassesService:IEyeglassesService
    {
        private readonly IEyeglassesRepository _eyeglassesRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _rootPath;

        public EyeglassesService(IEyeglassesRepository eyeglassesRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _eyeglassesRepository = eyeglassesRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
        }

        public CreatedResultDto Create(EyeglassesCreateDto createDto)
        {
            if (_eyeglassesRepository.IsExist(x => x.Name == createDto.Name))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", $"Name already take");
            var entity = _mapper.Map<Eyeglasses>(createDto);
            entity.ImageName = FileManager.Save(createDto.ImageName, _rootPath, "uploads/mainimages/eyeglasses");
            _eyeglassesRepository.Add(entity);
            _eyeglassesRepository.Commit();

            return _mapper.Map<CreatedResultDto>(entity);
        }

        public void Edit(int id, EyeglassesEditDto editDto)
        {
            var entity = _eyeglassesRepository.Get(x => x.Id == id);
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id: {id}");
            if (entity.Name != editDto.Name && _eyeglassesRepository.IsExist(x => x.Name == editDto.Name))
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
                entity.ImageName = FileManager.Save(editDto.ImageName, _rootPath, "uploads/mainimages/eyeglasses");
            }
            _eyeglassesRepository.Commit();
            if (existMainImages != null)
                FileManager.Delete(_rootPath, "uploads/mainimages/eyeglasses", existMainImages);
        }
        public List<EyeglassesGetAllDto> GetAll()
        {
            var entities = _eyeglassesRepository.GetQueryable(x => true, "Colors.Color").ToList();
            var getallDto = _mapper.Map<List<EyeglassesGetAllDto>>(entities);
            var baseUrl = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);
            for (int i = 0; i < getallDto.Count; i++)
            {
                getallDto[i].ImageUrl = baseUrl + "/uploads/mainimages/eyeglasses/" + entities[i].ImageName;
                var dto = getallDto[i];
                var entity = entities.FirstOrDefault(e => e.Id == dto.Id);

                if (entity != null && entity.Colors != null)
                {
                    dto.Colors = entity.Colors.Select(c =>
                    {
                        if (c != null && c.Color != null)
                        {
                            return new EyeglassesGetAllColorDto
                            {
                                ColorId = c.ColorId,
                                Color = new EyeColorAllDto
                                {
                                    ColorName = c.Color.ColorName,
                                    ColorImage = c.Color.ColorImage
                                }
                            };
                        }
                        else
                        {
                            return new EyeglassesGetAllColorDto
                            {
                                ColorId = c.ColorId,
                                Color = new EyeColorAllDto
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

        public EyeglassesGetDto GetById(int id)
        {
            var entity = _eyeglassesRepository.Get(x => x.Id == id, "Colors.Color");
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id:{id}");
            var getdto = _mapper.Map<EyeglassesGetDto>(entity);
            var baseUrl = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);
            getdto.ImageUrl = baseUrl + "/uploads/mainimages/eyeglasses/" + entity.ImageName;
            if (entity.Colors != null)
            {
                getdto.Colors = entity.Colors.Select(c =>
                {
                    return new EyeglassesGetColorDto
                    {
                        ColorId = c.ColorId,
                        Color = new EyeglassesGetColorDto.EyeColorGetDto
                        {
                            ColorName = c.Color.ColorName,
                            ColorImage = c.Color.ColorImage
                        }
                    };
                }).ToList();
            }
            else
            {
                getdto.Colors = new List<EyeglassesGetColorDto>();
            }
            return getdto;
        }
        public void Delete(int id)
        {
            var entity = _eyeglassesRepository.Get(x => x.Id == id);
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id: {id}");
            _eyeglassesRepository.Delete(entity);
            _eyeglassesRepository.Commit();
        }
    }
}
