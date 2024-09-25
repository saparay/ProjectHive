using Microsoft.AspNetCore.Mvc;
using ProjectHive.API.Models.DTO;
using ProjectHive.API.Services;

namespace ProjectHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeographyLocationController : Controller
    {
        private readonly IGeographyLocationService _geographyLocationService;

        public GeographyLocationController(IGeographyLocationService geographyLocationService)
        {
            _geographyLocationService = geographyLocationService;
        }

        [HttpGet]
        public Task<List<GeographyLocationDto>> GetAllGeographyLocations()
        {
            return _geographyLocationService.GetAllGeographyLocationsAsync();
        }
    }
}
