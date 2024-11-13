﻿using Infra.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Dtos
{
    public class VehicleDetailDto : BaseDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public int Year { get; set; }
    }
}