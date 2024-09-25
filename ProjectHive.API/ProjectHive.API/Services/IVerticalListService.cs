using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Services
{
    public interface IVerticalListService
    {
        Task<List<VerticalListDto>> GetAllVerticalListAsync();
    }
}
