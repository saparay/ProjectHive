using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectHive.API.Data;
using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Services
{
    public class GeographyLocationService : IGeographyLocationService
    {
        private readonly ProjectHiveDbContext _projectHiveDbContext;
        private readonly IMapper _mapper;

        public GeographyLocationService(ProjectHiveDbContext projectHiveDbContext, IMapper mapper)
        {
            _projectHiveDbContext = projectHiveDbContext;
            _mapper = mapper;
        }
        public async Task<List<GeographyLocationDto>> GetAllGeographyLocationsAsync()
        {
            return _mapper.Map<List<GeographyLocationDto>>(await _projectHiveDbContext.GeographyLocation.ToListAsync());
        }
    }
}
