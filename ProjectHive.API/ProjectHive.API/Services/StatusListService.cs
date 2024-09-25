using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectHive.API.Data;
using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Services
{
    public class StatusListService : IStatusListService
    {
        private readonly ProjectHiveDbContext _projectHiveDbContext;
        private readonly IMapper _mapper;

        public StatusListService(ProjectHiveDbContext projectHiveDbContext, IMapper mapper)
        {
            _projectHiveDbContext = projectHiveDbContext;
            _mapper = mapper;
        }
        public async Task<List<StatusListDto>> GetAllStatusListAsync()
        {
            return _mapper.Map<List<StatusListDto>>(await _projectHiveDbContext.StatusList.ToListAsync());
        }
    }
}
