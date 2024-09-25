using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjectHive.API.Models
{
    [Table("Project_Tracker")]
    public class ProjectTracker
    {

        public int Id { get; set; }
        [Column(name: "Project_Id"), MaxLength(10), AllowNull]
        public string? ProjectId { get; set; }
        [Column(name: "Project_Name"), MaxLength(50), AllowNull]
        public string? ProjectName { get; set; }
        [Column(name: "Project_Description"), MaxLength(2000), AllowNull]
        public string? ProjectDescription { get; set; }
        [Column(name: "Arrival_Source"), MaxLength(50), AllowNull]
        public string? ArrivalSource { get; set; }
        [Column(name: "Arrival_Source_IG"), MaxLength(4), AllowNull]
        public string? ArrivalSourceIG { get; set; }
        [Column(name: "Customer_Name"), MaxLength(50), Required]
        public string? CustomerName { get; set; }
        [Column(name: "Customer_Email"), MaxLength(100), Required, EmailAddress]
        public string? CustomerEmail { get; set; }
        [Column(name: "Arrival_Date"), AllowNull]
        public DateOnly? ArrivalDate { get; set; }
        [Column(name: "Questions_Submission_Date"), AllowNull]
        public DateOnly? QuestionsSubmissionDate { get; set; }
        [Column(name: "Questions_Response_Date"), AllowNull]
        public DateOnly? QuestionsResponseDate { get; set; }
        [Column(name: "Submission_Date"), AllowNull]
        public DateOnly? SubmissionDate { get; set; }
        [Column(name: "Client_Presentation_Date"), AllowNull]
        public DateOnly? ClientPresentationDate { get; set; }
        [Column(name: "DealDecision_Date"), AllowNull]
        public DateOnly? DealDecisionDate { get; set; }
        [Column(name: "Expected_Project_Start_Date"), AllowNull]
        public DateOnly? ExpectedProjectStartDate { get; set; }
        [Column(name: "Closure_Date"), AllowNull]
        public DateOnly? ClosureDate { get; set; }
        [Column(name: "Revenue_Start_Date"), AllowNull]
        public DateOnly? RevenueStartDate { get; set; }
        [Column(name: "Solution_Architect"), MaxLength(50), AllowNull]
        public string? SolutionArchitect { get; set; }
        [Column(name: "Up_Or_Cross_Sell"), AllowNull]
        public bool? UpOrCrossSell { get; set; }
        [Column(name: "Up_Or_Cross_Selling_Description"), MaxLength(2000), AllowNull]
        public string? UpOrCrossSellingDescription { get; set; }
        [Column(name: "Prior_Practice_Experience_With_Customer"), MaxLength(200), AllowNull]
        public string? PriorPracticeExperienceWithCustomer { get; set; }
        [Column(name: "Reason_For_Not_Proposing_Tools"), MaxLength(200), AllowNull]
        public string? ResonForNotProposingTools { get; set; }
        [Column(name: "Deal_TCV"), AllowNull]
        public float? DealTCV { get; set; }
        [Column(name: "Deal_PAT"), AllowNull]
        public float? DealPAT { get; set; }
        [Column(name: "Win_Probability"), AllowNull]
        public int? WinProbability { get; set; }
        [Column(name: "Overall_Team_Size"), AllowNull]
        public int? OverallTeamSize { get; set; }
        [Column(name: "Total_Team_Size"), AllowNull]
        public int? TotalTeamSize { get; set; }
        [Column(name: "Mail_List"), MaxLength(2000), AllowNull]
        public string? MailList { get; set; }
        [Column(name: "Comments"), MaxLength(2000), AllowNull]
        public string? Comments { get; set; }
        [Column(name: "Created_Date"), Required]
        public DateTime CreatedDate { get; set; }
        [Column(name: "Created_By"), Required]
        public required string CreatedBy { get; set; }
        [Column(name: "Last_Updated_Date"), Required]
        public DateTime LastUpdatedDate { get; set; }
        [Column(name: "Last_Updated_By"), Required]
        public required string LastUpdatedBy { get; set; }


        // Navigation properties

        public virtual ICollection<GeographyLocation>? GeographyLocations { get; set; }

        [Column(name:"Account_List_Id"), AllowNull]
        [JsonIgnore]
        public int? AccountListId { get; set; }
        //[JsonIgnore]
        public virtual AccountList? AccountList { get; set; }
        [JsonIgnore]
        [Column(name:"Status_List_Id"), AllowNull]
        public int? StatusListId { get; set; }
        //[JsonIgnore]
        public virtual StatusList? StatusList { get; set; }
        [JsonIgnore]
        [Column(name: "Vertical_List_Id"), AllowNull]
        public int? VerticalListId { get; set; }
        //[JsonIgnore]
        public virtual VerticalList? VerticalList { get; set; }
    }
}
