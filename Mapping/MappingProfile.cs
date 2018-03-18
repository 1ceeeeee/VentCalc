using AutoMapper;
using VentCalc.Controllers.Resources;
using VentCalc.Models;

namespace VentCalc.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Region, RegionResource>();
            CreateMap<City, CityResource>();
        }
    }
}