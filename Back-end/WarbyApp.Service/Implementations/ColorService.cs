using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Core.Repositories;
using WarbyApp.Data.Repositories;
using WarbyApp.Service.Dtos.ColorDtos;
using WarbyApp.Service.Dtos.Common;
using WarbyApp.Service.Dtos.EyeglassesDtos;
using WarbyApp.Service.Exceptions;
using WarbyApp.Service.Helpers;
using WarbyApp.Service.Interfaces;
using static WarbyApp.Service.Dtos.EyeglassesDtos.EyeglassesGetAllColorDto;

namespace WarbyApp.Service.Implementations
{
    public class ColorService:IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _rootPath;

        public ColorService(IColorRepository colorRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
        }
        public CreatedResultDto Create(ColorCreateDto createDto)
        {
            if (_colorRepository.IsExist(x => x.ColorName == createDto.ColorName))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "ColorName", $"ColorName already take");
            var entity = _mapper.Map<Color>(createDto);
            entity.ColorImage = FileManager.Save(createDto.ColorImage, _rootPath, "uploads/colorimages");
            _colorRepository.Add(entity);
            _colorRepository.Commit();

            return _mapper.Map<CreatedResultDto>(entity);
        }

        public void Delete(int id)
        {
            var entity = _colorRepository.Get(x => x.Id == id);
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Color not found by id: {id}");
            _colorRepository.Delete(entity);
            _colorRepository.Commit();
        }

        public void Edit(int id, ColorEditDto editDto)
        {
            var entity = _colorRepository.Get(x => x.Id == id);
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Color not found by id: {id}");
            if (entity.ColorName != editDto.ColorName && _colorRepository.IsExist(x => x.ColorName == editDto.ColorName))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", "Name already exists");
            entity.ColorName = editDto.ColorName;
            string existMainImages = null;

            if (editDto.ColorImage != null)
            {
                existMainImages = entity.ColorImage;
                entity.ColorImage = FileManager.Save(editDto.ColorImage, _rootPath, "uploads/colorimages");
            }
            _colorRepository.Commit();
            if (existMainImages != null)
                FileManager.Delete(_rootPath, "uploads/colorimages", existMainImages);
        }

        public List<ColorGetAllDto> GetAll()
        {
            var entities = _colorRepository.GetQueryable(x => true).ToList();
            return _mapper.Map<List<ColorGetAllDto>>(entities);
        }

        public ColorGetDto GetById(int id)
        {
            var entity = _colorRepository.Get(x => x.Id == id);
            if (entity == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Color not found by id:{id}");
            return _mapper.Map<ColorGetDto>(entity);
        }
    }
}
