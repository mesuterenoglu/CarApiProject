

using AutoMapper;
using CarProject.Application.DTOs;
using CarProject.Domain.Entities;

namespace CarProject.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Bus, BusDto>().ReverseMap();
            CreateMap<Boat, BoatDto>().ReverseMap();
        }
    }
}
