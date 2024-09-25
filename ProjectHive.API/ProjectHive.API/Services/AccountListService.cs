using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectHive.API.Data;
using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Services
{
    public class AccountListService : IAccountListService
    {
        private readonly ProjectHiveDbContext _projectHiveDbContext;
        private readonly IMapper _mapper;

        public AccountListService(ProjectHiveDbContext projectHiveDbContext, IMapper mapper)
        {
            _projectHiveDbContext = projectHiveDbContext;
            _mapper = mapper;
        }
        public async Task<List<AccountListDto>> GetAllAccountsAsync()
        {
            return _mapper.Map<List<AccountListDto>>(await _projectHiveDbContext.AccountList.ToListAsync());
        }
    }
}
