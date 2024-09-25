using Microsoft.AspNetCore.Mvc;
using ProjectHive.API.Models.DTO;
using ProjectHive.API.Services;

namespace ProjectHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerticalListController : Controller
    {
        private readonly IVerticalListService _verticalListService;
        public VerticalListController(IVerticalListService verticalListService)
        {
            _verticalListService = verticalListService;
        }

        [HttpGet]
        public Task<List<VerticalListDto>> GetAllVerticalList()
        {
            return _verticalListService.GetAllVerticalListAsync();
        }
    }
}
