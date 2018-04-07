using AutoMapper;
using VentCalc.Controllers.Resources;
using VentCalc.Models;

namespace VentCalc.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Region, RegionResource>();
            CreateMap<City, CityResource>();
            CreateMap<BuildingKind, BuildingKindResource>();
            CreateMap<BuildingPurpose, BuildingPurposeResource>();
            CreateMap<BuildingType, BuildingTypeResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<Project, ProjectResource>();
        }
    }
}