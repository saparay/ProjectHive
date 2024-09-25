using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectHive.API.Data;
using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Services
{
    public class VerticalListService : IVerticalListService
    {
        private readonly ProjectHiveDbContext _projectHiveDbContext;
        private readonly IMapper _mapper;

        public VerticalListService(ProjectHiveDbContext projectHiveDbContext, IMapper mapper)
        {
            _projectHiveDbContext = projectHiveDbContext;
            _mapper = mapper;
        }
        public async Task<List<VerticalListDto>> GetAllVerticalListAsync()
        {
            return _mapper.Map<List<VerticalListDto>>(await _projectHiveDbContext.VerticalList.ToListAsync());
        }
    }
}
