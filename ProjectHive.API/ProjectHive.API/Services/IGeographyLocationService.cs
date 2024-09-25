using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Services
{
    public interface IGeographyLocationService
    {
        Task<List<GeographyLocationDto>> GetAllGeographyLocationsAsync();
    }
}
