using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.BL.Concretes
{
    public class VehicleService : IVehicleService
    {
        private readonly IAracKiralamaRepository _aracKiralamaRepository;

        public VehicleService(IAracKiralamaRepository aracKiralamaRepository)
        {
            _aracKiralamaRepository = aracKiralamaRepository;
        }

        public async Task<List<VehicleListDto>> GetActiveVehicles()
        {
            var data = await _aracKiralamaRepository.ListProjectAsync<Vehicle, VehicleListDto>(d => d.StatusId != 0);
            return data;
        }

        public async Task<VehicleDetailDto> GetVehicleDetail(string plate)
        {
            var data = await _aracKiralamaRepository.GetProjectAsync<Vehicle, VehicleDetailDto>(d => d.Plate == plate);
            return data;
        }

        public async Task<Vehicle> GetVehicleDetailWithColor(string color)
        {
            var data = await _aracKiralamaRepository.GetAsync<Vehicle>(d => d.Color == color);
            return data;
        }
    }
}
