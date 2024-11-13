using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EGM.AracKiralama.API.Controllers
{
    //[Authorize(Roles = "admin")]
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
            var data = await _vehicleService.GetVehicleDetailAsync(plate);
            return Ok(data);
        }
        [HttpGet("getvehiclewithcolor/{color}")]
        public async Task<IActionResult> GetVehiclesByColorAsync(string color)
        {
            var data = await _vehicleService.GetVehicleDetailWithColorAsync(color);
            return Ok(data);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleAddDto vehicleAddDto)
        {
            var result = await _vehicleService.AddVehicleAsync(vehicleAddDto);
            return Ok(result);
        }
    }
}
