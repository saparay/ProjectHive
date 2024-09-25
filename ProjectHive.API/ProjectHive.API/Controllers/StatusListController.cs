using Microsoft.AspNetCore.Mvc;
using ProjectHive.API.Models.DTO;
using ProjectHive.API.Services;

namespace ProjectHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusListController : Controller
    {
        private readonly IStatusListService _statusListService;

        public StatusListController(IStatusListService statusListService)
        {
            _statusListService = statusListService;
        }
        [HttpGet]
        public Task<List<StatusListDto>> GetAllStatusList()
        {
            return _statusListService.GetAllStatusListAsync();
        }
    }
}
