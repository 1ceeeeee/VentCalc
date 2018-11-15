using AutoMapper;
using VentCalc.Controllers.Resources;
using VentCalc.Models;

namespace VentCalc.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile() {
            // Domain to API Resource
            CreateMap<Region, RegionResource>();
            CreateMap<City, CityResource>();
            CreateMap<BuildingKind, BuildingKindResource>();
            CreateMap<BuildingPurpose, BuildingPurposeResource>();
            CreateMap<BuildingType, BuildingTypeResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<Project, ProjectResource>();
            CreateMap<SaveProjectResource, Project>()
                .ForMember(v => v.CreateUserId, opt => opt.Ignore());
            CreateMap<RoomTypeValue, RoomTypeValueResource>();
            CreateMap<RoomType, RoomTypeResource>();
            CreateMap<PortalUser, PortalUserResource>();
            CreateMap<AppUser, PortalUserResource>();

            CreateMap<PortalUser, PortalUserResource>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Identity.FirstName));
            CreateMap<PortalUser, PortalUserResource>()
                .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.Identity.SecondName));
            CreateMap<PortalUser, PortalUserResource>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Identity.LastName));
            CreateMap<PortalUser, PortalUserResource>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Identity.UserName));
            CreateMap<PortalUser, PortalUserResource>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Identity.Email));
            CreateMap<PortalUser, PortalUserResource>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<PortalUser, PortalUserResource>()
                .ForMember(dest => dest.IdentityId, opt => opt.MapFrom(src => src.Identity.Id));

            // API Resource to Domain
            CreateMap<SaveRoomResource, Room>()
                .ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<SaveProjectResource, Project>()
                .ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<PortalUserResource, PortalUser>()
                .ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<PortalUserResource, AppUser>()
                .ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<ProjectResource, Project>()
                .ForMember(v => v.CreateUserId, opt => opt.Ignore());
            CreateMap<SaveProjectResource, Project>()
                .ForMember(v => v.CreateUserId, opt => opt.Ignore());

        }
    }
}