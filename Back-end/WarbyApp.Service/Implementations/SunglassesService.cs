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
using WarbyApp.Data.Repositories;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;
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
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        private string _rootPath;

        public SunglassesService(ISunglassesRepository sunglassesRepository, IColorRepository colorRepository, IMapper mapper)
        {
            _sunglassesRepository = sunglassesRepository;
            _colorRepository = colorRepository;
            _mapper = mapper;
            _rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
        }

        public CreatedResultDto Create(SunglassesCreateDto createDto)
        {
            if (_sunglassesRepository.IsExist(x => x.Name == createDto.Name))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", $"Name already take");
            if (!IsColorIdValid(createDto.Colors.ColorId))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "ColorId", $"ColorId does not exist");
            var entity = _mapper.Map<Sunglasses>(createDto);
            entity.ImageName = FileManager.Save(createDto.ImageName, _rootPath, "uploads/mainimages/sunglasses");
            _sunglassesRepository.Add(entity);
            _sunglassesRepository.Commit();

            return _mapper.Map<CreatedResultDto>(entity);
        }
        private bool IsColorIdValid(int colorId)
        {
            return _colorRepository.IsExist(c => c.Id == colorId);
        }

        public void Edit(int id, SunglassesEditDto editDto)
        {
            var entity = _sunglassesRepository.Get(x => x.Id == id, "Colors.Color");
            var entity2 = _colorRepository.GetQueryable(x => true).ToList();
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
            var existingColorIds = new HashSet<int>(entity2.Select(x => x.Id));
            if (editDto.ColorIdsToAdd != null && editDto.ColorIdsToAdd.Any())
            {
                for (int i = 0; i < editDto.ColorIdsToAdd.Count; i++)
                {
                    if (existingColorIds.Contains(editDto.ColorIdsToAdd[i]))
                    {
                        if (!entity.Colors.Any(x => x.ColorId == editDto.ColorIdsToAdd[i]))
                        {
                            entity.Colors.Add(new SunglassesColor
                            {
                                ColorId = editDto.ColorIdsToAdd[i]
                            });
                        }
                        else
                        {
                            throw new RestException(System.Net.HttpStatusCode.NotFound, $"Color id:{editDto.ColorIdsToAdd[i]} is now available: ");
                        }
                    }
                    else
                    {
                        throw new RestException(System.Net.HttpStatusCode.NotFound, $"Color id:{editDto.ColorIdsToAdd[i]} is not available");
                    }
                }
            }
            if (editDto.ColorIdsToRemove != null && editDto.ColorIdsToRemove.Any())
            {
                for (int i = 0; i < editDto.ColorIdsToRemove.Count; i++)
                {
                    if (existingColorIds.Contains(editDto.ColorIdsToRemove[i]))
                    {
                        if (!entity.Colors.Any(x => x.ColorId == editDto.ColorIdsToRemove[i]))
                        {
                            throw new RestException(System.Net.HttpStatusCode.NotFound, $"Color id:{editDto.ColorIdsToRemove[i]} is not available: ");
                        }
                        else
                        {
                            entity.Colors.Remove(entity.Colors[i]);
                        }
                    }
                    else
                    {
                        throw new RestException(System.Net.HttpStatusCode.NotFound, $"Color id:{editDto.ColorIdsToRemove[i]} is not available");
                    }
                }
            }

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
            
            return _mapper.Map<List<SunglassesGetAllDto>>(entities);
        }

        public SunglassesGetDto GetById(int id)
        {
            var entity = _sunglassesRepository.Get(x => x.Id == id, "Colors.Color");
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id:{id}");
            
            return _mapper.Map<SunglassesGetDto>(entity);
        }
        public void Delete(int id)
        {
            var entity = _sunglassesRepository.Get(x => x.Id == id);
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id: {id}");
            _sunglassesRepository.Delete(entity);
            _sunglassesRepository.Commit();
        }

        public PaginatedListDto<SunglassesGetPaginatedListItemDto> GetAllPaginated(int page)
        {
            var query = _sunglassesRepository.GetQueryable(x => true);
            var entities = query.Skip((page - 1) * 4).Take(4).ToList();
            var items = _mapper.Map<List<SunglassesGetPaginatedListItemDto>>(entities);
            return new PaginatedListDto<SunglassesGetPaginatedListItemDto>(items, page, 4, query.Count());
        }
    }
}
