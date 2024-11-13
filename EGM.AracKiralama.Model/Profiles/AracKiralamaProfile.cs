﻿using AutoMapper;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Profiles
{
    public class AracKiralamaProfile : Profile
    {
        public AracKiralamaProfile()
        {
            CreateMap<Vehicle, VehicleListDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name));
            ;
            CreateMap<Vehicle, VehicleDetailDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name));
            ;
            CreateMap<User, UserDto>();
            CreateMap<Vehicle, VehicleAddDto>().ReverseMap();
        }
    }
}