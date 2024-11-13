using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using Infrastructure.Model.Dtos;

namespace EGM.AracKiralama.BL.Abstracts
{
    public interface IVehicleService
    {
        Task<List<VehicleListDto>> GetActiveVehicles();
        Task<VehicleDetailDto> GetVehicleDetailAsync(string plate);
        Task<Vehicle> GetVehicleDetailWithColorAsync(string color);
        Task<ResultDto<VehicleAddDto>> AddVehicleAsync(VehicleAddDto item);
    }
}
