using Infra.Model.Dtos;

namespace EGM.AracKiralama.Model.Dtos
{
    public class VehicleAddDto : BaseDto
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }
        public short BrandId { get; set; }
        public short? ModelId { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
