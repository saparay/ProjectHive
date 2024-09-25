using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Services
{
    public interface IStatusListService
    {
        Task<List<StatusListDto>> GetAllStatusListAsync();
    }
}
