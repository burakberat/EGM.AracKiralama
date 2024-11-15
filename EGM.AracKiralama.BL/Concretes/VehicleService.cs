using AutoMapper;
using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using Infrastructure.Cache;
using Infrastructure.Model.Dtos;

namespace EGM.AracKiralama.BL.Concretes
{
    public class VehicleService : IVehicleService
    {
        private readonly IAracKiralamaRepository _aracKiralamaRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public VehicleService(IAracKiralamaRepository aracKiralamaRepository, IMapper mapper, ICacheService cacheService)
        {
            _aracKiralamaRepository = aracKiralamaRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        //[Cache("VehicleList", 300)]
        public async Task<List<VehicleListDto>> GetActiveVehicles()
        {
            //Redis veya InMemory (program.cs de hangisi açıksa)
            var list = await _cacheService.GetObjectAsync<List<VehicleListDto>>("ActiveVehicles");
            if (list != null)
            {
                return list;
            }

            var data = await _aracKiralamaRepository.ListProjectAsync<Vehicle, VehicleListDto>(d => d.StatusId != 0);
            await _cacheService.SetObjectAsync("ActiveVehicles", data);

            return data;
        }

        public async Task<VehicleDetailDto> GetVehicleDetailAsync(string plate)
        {
            //Custom Exception
            //throw new TimeException("Araç sorgulamada 20:00 sonrası işlem yapmaya çalıştın.");
            var data = await _aracKiralamaRepository.GetProjectAsync<Vehicle, VehicleDetailDto>(d => d.Plate == plate);
            return data;
        }

        public async Task<Vehicle> GetVehicleDetailWithColorAsync(string color)
        {
            var data = await _aracKiralamaRepository.GetAsync<Vehicle>(d => d.Color == color);
            return data;
        }

        public async Task<ResultDto<VehicleAddDto>> AddVehicleAsync(VehicleAddDto item)
        {
            var data = _mapper.Map<Vehicle>(item);
            await _aracKiralamaRepository.AddAsync(data);
            await _aracKiralamaRepository.SaveChangesAsync();
            item.Id = data.Id;
            return ResultDto<VehicleAddDto>.Success(item);

        }
    }
}
