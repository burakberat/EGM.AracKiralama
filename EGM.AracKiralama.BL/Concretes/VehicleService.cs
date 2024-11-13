using AutoMapper;
using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using Infrastructure.Model.Dtos;

namespace EGM.AracKiralama.BL.Concretes
{
    public class VehicleService : IVehicleService
    {
        private readonly IAracKiralamaRepository _aracKiralamaRepository;
        private readonly IMapper _mapper;

        public VehicleService(IAracKiralamaRepository aracKiralamaRepository, IMapper mapper)
        {
            _aracKiralamaRepository = aracKiralamaRepository;
            _mapper = mapper;
        }

        public async Task<List<VehicleListDto>> GetActiveVehicles()
        {
            var data = await _aracKiralamaRepository.ListProjectAsync<Vehicle, VehicleListDto>(d => d.StatusId != 0);
            return data;
        }

        public async Task<VehicleDetailDto> GetVehicleDetailAsync(string plate)
        {
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
