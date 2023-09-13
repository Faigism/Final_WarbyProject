using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Core.Repositories;
using WarbyApp.Data.Repositories;
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
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        private string _rootPath;

        public EyeglassesService(IEyeglassesRepository eyeglassesRepository, IColorRepository colorRepository, IMapper mapper)
        {
            _eyeglassesRepository = eyeglassesRepository;
            _colorRepository = colorRepository;
            _mapper = mapper;
            _rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
        }

        public CreatedResultDto Create(EyeglassesCreateDto createDto)
        {
            if (_eyeglassesRepository.IsExist(x => x.Name == createDto.Name))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", $"Name already take");
            if (!IsColorIdValid(createDto.Colors.ColorId))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "ColorId", $"ColorId does not exist");
            var entity = _mapper.Map<Eyeglasses>(createDto);
            entity.ImageName = FileManager.Save(createDto.ImageName, _rootPath, "uploads/mainimages/eyeglasses");
            _eyeglassesRepository.Add(entity);
            _eyeglassesRepository.Commit();

            return _mapper.Map<CreatedResultDto>(entity);
        }
        private bool IsColorIdValid(int colorId)
        {
            return _colorRepository.IsExist(c => c.Id == colorId);
        }

        public void Edit(int id, EyeglassesEditDto editDto)
        {
            var entity = _eyeglassesRepository.Get(x => x.Id == id, "Colors.Color");
            var entity2 = _colorRepository.GetQueryable(x => true).ToList();
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
            var existingColorIds = new HashSet<int>(entity2.Select(x => x.Id));
            if (editDto.ColorIdsToAdd != null && editDto.ColorIdsToAdd.Any())
            {
                for (int i = 0; i < editDto.ColorIdsToAdd.Count; i++)
                {
                    if (existingColorIds.Contains(editDto.ColorIdsToAdd[i]))
                    {
                        if (!entity.Colors.Any(x => x.ColorId == editDto.ColorIdsToAdd[i]))
                        {
                            entity.Colors.Add(new EyeglassesColor
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
            return _mapper.Map<List<EyeglassesGetAllDto>>(entities);
        }

        public EyeglassesGetDto GetById(int id)
        {
            var entity = _eyeglassesRepository.Get(x => x.Id == id, "Colors.Color");
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id:{id}");
            return _mapper.Map<EyeglassesGetDto>(entity);
        }
        public void Delete(int id)
        {
            var entity = _eyeglassesRepository.Get(x => x.Id == id);
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Eyeglasses not found by id: {id}");
            _eyeglassesRepository.Delete(entity);
            _eyeglassesRepository.Commit();
        }

        public PaginatedListDto<EyeglassesGetPaginatedListItemDto> GetAllPaginated(int page)
        {
            var query = _eyeglassesRepository.GetQueryable(x => true, "Colors.Color");
            var entities = query.Skip((page - 1) * 4).Take(4).ToList();
            var items = _mapper.Map<List<EyeglassesGetPaginatedListItemDto>>(entities);
            return new PaginatedListDto<EyeglassesGetPaginatedListItemDto>(items, page, 4, query.Count());
        }
    }
}
