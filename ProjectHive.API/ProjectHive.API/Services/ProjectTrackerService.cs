using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using ProjectHive.API.Data;
using ProjectHive.API.Models;
using ProjectHive.API.Models.DTO;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<MemoryStream> ExportDataToExcel()
        {
            var columnNames = await GetColumnNamesFromView("projecttrackerdemo");

            //var data = await _projectHiveDbContext.ProjectTrackerViewEx.ToListAsync();

            //var stream = new MemoryStream();

            //Console.WriteLine("columnNames", columnNames);
            //using (var package = new ExcelPackage(stream)) 
            //{
            //    var worksheet = package.Workbook.Worksheets.Add("ProjectTracker");

            //    for (int colIndex = 0; colIndex < columnNames.Count; colIndex++)
            //    {
            //        worksheet.Cells[1, colIndex+1].Value = columnNames[colIndex];

            //    }

            //    for(int rowIndex = 0; rowIndex < data.Count; rowIndex++)
            //    {
            //        var row = data[rowIndex];
            //        for(int colIndex = 0; colIndex<columnNames.Count; colIndex++)
            //        {
            //            var propertyName = columnNames[colIndex];
            //            var propertyValue = row.GetType().GetProperty(propertyName)?.GetValue(row, null);
            //            worksheet.Cells[rowIndex+2, colIndex+1].Value = propertyValue?.ToString();
            //        }
            //    }
            //    package.Save();
            //}
            //stream.Position = 0;
            var data = await _projectHiveDbContext.ProjectTrackerViewEx.ToListAsync();

            // Create Excel file
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Data");

                // Add headers (assuming your SQL view has columns `Column1`, `Column2`, etc.)
                worksheet.Cells[1, 1].Value = "Column1";
                worksheet.Cells[1, 2].Value = "Column2";
                worksheet.Cells[1, 3].Value = "Column3";
                // Add more headers if needed

                // Add data to cells (assuming your SQL view returns a list of entities)
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Project_Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Project_Name;
                    worksheet.Cells[i + 2, 3].Value = data[i].Project_Description;
                    // Add more columns if needed
                }

                package.Save();
            }

            stream.Position = 0;
            var fileName = $"Data_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            // Return the Excel file for download
            //return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            return stream;


        }
        private async Task<List<string>> GetColumnNamesFromView(string viewName)
        {
            var columnNames = new List<string>();

            using (var command = _projectHiveDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
                SELECT COLUMN_NAME
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'projecttrackerview'";

                // Add parameter to prevent SQL injection
                var parameter = command.CreateParameter();
                parameter.ParameterName = "projecttrackerview";
                parameter.Value = viewName;
                command.Parameters.Add(parameter);

                _projectHiveDbContext.Database.OpenConnection();
                using (var result = await command.ExecuteReaderAsync())
                {
                    while (await result.ReadAsync())
                    {
                        columnNames.Add(result.GetString(0));
                    }
                }
            }
            Console.WriteLine("columnNames", columnNames);
            return columnNames;
        }

        public List<ProjectTrackerViewEx> GetProjects()
        {
            return _projectHiveDbContext.ProjectTrackerViewEx.ToList();
        }
    }
}
