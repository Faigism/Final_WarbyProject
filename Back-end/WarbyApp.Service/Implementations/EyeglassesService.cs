using AutoMapper;
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

namespace WarbyApp.Service.Implementations
{
    public class EyeglassesService:IEyeglassesService
    {
        private readonly IEyeglassesRepository _eyeglassesRepository;
        private readonly IMapper _mapper;
        private string _rootPath;

        public EyeglassesService(IEyeglassesRepository eyeglassesRepository, IMapper mapper)
        {
            _eyeglassesRepository = eyeglassesRepository;
            _mapper = mapper;
            _rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
        }

        public CreatedResultDto Create(EyeglassesCreateDto createDto)
        {
            if (_eyeglassesRepository.IsExist(x => x.Name == createDto.Name))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", $"Name already take");

            var entity = _mapper.Map<Eyeglasses>(createDto);

            entity.EyeglassesImages = FileManager.Save(createDto.ImageFiles, _rootPath, "uploads/eyeglasses");

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

            _eyeglassesRepository.Commit();
        }
        public List<EyeglassesGetAllDto> GetAll()
        {
            var entities = _eyeglassesRepository.GetQueryable(x => true).ToList();

            return _mapper.Map<List<EyeglassesGetAllDto>>(entities);
        }

        public EyeglassesGetDto GetById(int id)
        {
            var entity = _eyeglassesRepository.Get(x => x.Id == id);
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
    }
}
