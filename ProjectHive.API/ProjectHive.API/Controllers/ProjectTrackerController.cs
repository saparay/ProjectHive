using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHive.API.Data;
using ProjectHive.API.Models;
using ProjectHive.API.Models.DTO;
using ProjectHive.API.Services;

namespace ProjectHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTrackerController : Controller
    {
        public readonly IProjectTrackerService _projectTrackerService;

        public ProjectTrackerController(IProjectTrackerService projectTrackerService)
        {
            _projectTrackerService = projectTrackerService;
        }

        //[HttpGet]
        //public Task<List<ProjectTrackerDto>> GetAllProjectTrackers()
        //{
        //    return _projectTrackerService.GetAllProjectTrackers();
        //}

        [HttpPost]
        public IActionResult GetPaginatedProjectTrackers([FromBody] ProjectTrackerRequestBodyDto? requestBodyDto, int page=1, int pageSize=8)
        {

           
            // Fetch the data for the requested page
            var values = _projectTrackerService.GetPaginatedProjectTracker(requestBodyDto, page, pageSize);
            var projectTrackerDto = _projectTrackerService.ProjectTrackerMapper(values);

            var totalCount = projectTrackerDto.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            projectTrackerDto = projectTrackerDto.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            // Create pagination metadata
            var pagination = new
            {
                data = projectTrackerDto,
                next = page < totalPages ? Url.Action("GetPaginatedProjectTrackers", new { page = page + 1, pageSize }) : null,
                previous = page > 1 ? Url.Action("GetPaginatedProjectTrackers", new { page = page - 1, pageSize }) : null,
                hasNext = page < totalPages, // Indicates if there's a next page
                totalCount,
            };

            return Ok(pagination);
        }

        [HttpGet("{id}")]
        public Task<ProjectTrackerDto> GetProjectTrackers( int id)
        {
            return _projectTrackerService.GetProjectTraker(id);
        }

        [HttpGet("export-excel")]
        public IActionResult ExportProjectTrackerToExcel()
        {
            var stream = _projectTrackerService.ExportDataToExcel().Result;
            var fileName = $"ProjectTracker_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [HttpGet("demo")]
        public List<ProjectTrackerViewEx> GetProjectTrackersView()
        {
            return _projectTrackerService.GetProjects();
        }
    }
}
