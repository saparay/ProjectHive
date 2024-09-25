namespace ProjectHive.API.Models.DTO
{
    public class ProjectTrackerDto
    {
        public int Id { get; set; }
        public string? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public string? ArrivalSource { get; set; }
        public string? ArrivalSourceIG { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public DateOnly? ArrivalDate { get; set; }
        public DateOnly? QuestionsSubmissionDate { get; set; }
        public DateOnly? QuestionsResponseDate { get; set; }
        public DateOnly? SubmissionDate { get; set; }
        public DateOnly? ClientPresentationDate { get; set; }
        public DateOnly? DealDecisionDate { get; set; }
        public DateOnly? ExpectedProjectStartDate { get; set; }
        public DateOnly? ClosureDate { get; set; }
        public DateOnly? RevenueStartDate { get; set; }
        public string? SolutionArchitect { get; set; }
        public bool? UpOrCrossSell { get; set; }
        public string? UpOrCrossSellingDescription { get; set; }
        public string? PriorPracticeExperienceWithCustomer { get; set; }
        public string? ResonForNotProposingTools { get; set; }
        public float? DealTCV { get; set; }
        public float? DealPAT { get; set; }
        public int? WinProbability { get; set; }
        public int? OverallTeamSize { get; set; }
        public int? TotalTeamSize { get; set; }
        public string? MailList { get; set; }
        public string? Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }

        public AccountListDto? AccountList { get; set; }
        public VerticalListDto? VerticalList { get; set; }
        public StatusListDto? StatusList { get; set; }
        public ICollection<GeographyLocationDto>? GeographyLocations { get; set; }
    }
}
