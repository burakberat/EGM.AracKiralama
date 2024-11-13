using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGM.AracKiralama.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("getvehicles")]
        public async Task<IActionResult> GetActiveVehicles()
        {
            var data = await _vehicleService.GetActiveVehicles();
            return Ok(data);
        }
        [HttpGet("getvehicle/{plate}")]
        public async Task<IActionResult> GetVehiclesByPlateAsync(string plate)
        {
            var data = await _vehicleService.GetVehicleDetail(plate);
            return Ok(data);
        }
        [HttpGet("getvehiclewithcolor/{color}")]
        public async Task<IActionResult> GetVehiclesByColorAsync(string color)
        {
            var data = await _vehicleService.GetVehicleDetailWithColor(color);
            return Ok(data);
        }
    }
}
