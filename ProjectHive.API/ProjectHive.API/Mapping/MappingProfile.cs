using AutoMapper;
using ProjectHive.API.Models;
using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Mapping
{


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountList, AccountListDto>().ReverseMap();
            CreateMap<GeographyLocation, GeographyLocationDto>().ReverseMap();
            CreateMap<ProjectTracker, ProjectTrackerDto>().ReverseMap();
            CreateMap<TechnologyFramework, TechnologyFrameworkDto>().ReverseMap();
            CreateMap<VerticalList, VerticalListDto>().ReverseMap();
            CreateMap<StatusList, StatusListDto>().ReverseMap();
        }
    }

}
