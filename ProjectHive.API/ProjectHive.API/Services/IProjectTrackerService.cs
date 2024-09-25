using Microsoft.AspNetCore.Mvc;
using ProjectHive.API.Models;
using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Services
{
    public interface IProjectTrackerService
    {
        List<ProjectTrackerDto> ProjectTrackerMapper(IQueryable<ProjectTracker> projectTrackerQueryable);
        IQueryable<ProjectTracker> GetPaginatedProjectTracker(ProjectTrackerRequestBodyDto requestBodyDto, int page = 1, int pageSize = 8);
        Task<ProjectTrackerDto> GetProjectTraker(int id);

        Task<byte[]?> ExportDataToExcel();


    }
}
