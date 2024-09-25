using AutoMapper;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using ProjectHive.API.Data;
using ProjectHive.API.Models;
using ProjectHive.API.Models.DTO;
using System.Data;

namespace ProjectHive.API.Services
{
    public class ProjectTrackerService : IProjectTrackerService
    {
        private readonly ProjectHiveDbContext _projectHiveDbContext;
        private readonly IMapper _mapper;

        public ProjectTrackerService(ProjectHiveDbContext projectHiveDbContext, IMapper mapper)
        {
            _projectHiveDbContext = projectHiveDbContext;
            _mapper = mapper;
        }
        public async Task<List<ProjectTrackerDto>> GetAllProjectTrackers()
        {
            var projectTrackerDto =  _mapper.Map<List<ProjectTrackerDto>>(
                await _projectHiveDbContext.ProjectTracker.ToListAsync());
            return projectTrackerDto;
        }

        public IQueryable<ProjectTracker> GetPaginatedProjectTracker(ProjectTrackerRequestBodyDto requestBodyDto, int page = 1, int pageSize = 8)
        {
            var query = _projectHiveDbContext.ProjectTracker.AsQueryable();
            if (requestBodyDto != null)
            {
                if (requestBodyDto.SearchText != null && requestBodyDto.SearchText != "")
                {
                    query = GetProjectTrackersSearch(requestBodyDto.SearchText, query);
                }

                if (requestBodyDto.AccountList != null && requestBodyDto.AccountList.Count > 0)
                {

                    query = GetAccountListFiltered(requestBodyDto.AccountList, query);
                }
                if (requestBodyDto.VerticalList != null && requestBodyDto.VerticalList.Count > 0)
                {

                    query = GetVerticalListFiltered(requestBodyDto.VerticalList, query);
                }
                if (requestBodyDto.StatusList != null && requestBodyDto.StatusList.Count > 0)
                {

                    query = GetStatusListFiltered(requestBodyDto.StatusList, query);
                }
                if (requestBodyDto.GeographyLocation != null && requestBodyDto.GeographyLocation.Count > 0)
                {

                    query = GetGeographyLocationFiltered(requestBodyDto.GeographyLocation, query);
                }
            }
            
            return query;
        }

        public IQueryable<ProjectTracker> GetAccountListFiltered(List<int> accountList, IQueryable<ProjectTracker> projectTrackers)
        {
            
            return projectTrackers = projectTrackers.Where(pt => accountList.Contains((int)pt.AccountListId));
            
        }
        public IQueryable<ProjectTracker> GetVerticalListFiltered(List<int> verticalList, IQueryable<ProjectTracker> projectTrackers)
        {
            return projectTrackers = projectTrackers.Where(pt => verticalList.Contains((int)pt.VerticalListId));
        }
        public IQueryable<ProjectTracker> GetStatusListFiltered(List<int> statusList, IQueryable<ProjectTracker> projectTrackers)
        {
            return projectTrackers = projectTrackers.Where(pt => statusList.Contains((int)pt.StatusListId));
        }

        public IQueryable<ProjectTracker> GetGeographyLocationFiltered(List<int> geographyLocation, IQueryable<ProjectTracker> projectTrackers)
        {
            return projectTrackers.Where(pt => pt.GeographyLocations
                    .Any(gl => geographyLocation.Contains(gl.Id)));
        }

        public IQueryable<ProjectTracker> GetProjectTrackersSearch(string searchText, IQueryable<ProjectTracker> projectTrackers)
        {
           
            return projectTrackers.Where(pt => pt.ProjectName.Contains(searchText) || pt.CustomerName.Contains(searchText));
        }


        public async Task<ProjectTrackerDto> GetProjectTraker(int id)
        {
            var projectTrackerDto = _mapper.Map<ProjectTrackerDto>(await _projectHiveDbContext.ProjectTracker.FirstOrDefaultAsync(p => p.Id == id));
            return projectTrackerDto;
        }

        public List<ProjectTrackerDto> ProjectTrackerMapper(IQueryable<ProjectTracker> projectTrackerQueryable)
        {
            return _mapper.Map<List<ProjectTrackerDto>>(projectTrackerQueryable.ToList());
        }

        public async Task<byte[]?> ExportDataToExcel()
        {

            var data = await _projectHiveDbContext.ProjectTrackerViewEx.ToListAsync();

            if (data == null || !data.Any())
                return null;

            // Create a DataTable to hold your data
            var dt = new DataTable("Projects");

            // Get the properties of your entity (assuming all properties should be included)
            var properties = typeof(ProjectTrackerViewEx).GetProperties();

            // Dynamically create columns based on the property names
            foreach (var prop in properties)
            {
                dt.Columns.Add(prop.Name);
            }

            // Populate DataTable with your data
            foreach (var item in data)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(item) ?? DBNull.Value; // Handles null values
                }
                dt.Rows.Add(values);
            }

            // Create an Excel file with ClosedXML
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(dt);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    // Return the Excel file
                    return content;
                }
            }


        }
    }
}
