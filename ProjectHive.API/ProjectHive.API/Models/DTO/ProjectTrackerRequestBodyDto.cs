namespace ProjectHive.API.Models.DTO
{
    public class ProjectTrackerRequestBodyDto
    {
        public string? SearchText { get; set; }
        public List<int>? AccountList { get; set; }
        public List<int>? StatusList { get; set; }
        public List<int>? VerticalList { get; set; }
        public List<int>? GeographyLocation { get; set; }
    }
}
