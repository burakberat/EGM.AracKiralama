using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.BL.Abstracts
{
    public interface IVehicleService
    {
        Task<List<VehicleListDto>> GetActiveVehicles();
        Task<VehicleDetailDto> GetVehicleDetail(string plate);
        Task<Vehicle> GetVehicleDetailWithColor(string color);
    }
}
