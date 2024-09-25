using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Services
{
    public interface IAccountListService
    {
        Task<List<AccountListDto>> GetAllAccountsAsync();
    }
}
