using ProjectHive.API.Models.DTO;

namespace ProjectHive.API.Models
{
    public class ProjectTrackerViewEx
    {
        public int Id { get; set; }
        public string? Project_Id { get; set; }
        public string? Project_Name { get; set; }
        public string? Project_Description { get; set; }
        public string? Arrival_Source { get; set; }
        public string? Arrival_Source_IG { get; set; }
        public string? Customer_Name { get; set; }
        public string? Customer_Email { get; set; }
        public DateOnly? Arrival_Date { get; set; }
        public DateOnly? Questions_Submission_Date { get; set; }
        public DateOnly? Questions_Response_Date { get; set; }
        public DateOnly? Submission_Date { get; set; }
        public DateOnly? Client_Presentation_Date { get; set; }
        public DateOnly? Deal_Decision_Date { get; set; }
        public DateOnly? Expected_Project_Start_Date { get; set; }
        public DateOnly? Closure_Date { get; set; }
        public DateOnly? Revenue_Start_Date { get; set; }
        public string? Solution_Architect { get; set; }
        public bool? Up_Or_Cross_Sell { get; set; }
        public string? Up_Or_Cross_Selling_Description { get; set; }
        public string? Prior_Practice_Experience_With_Customer { get; set; }
        public string? Reason_For_Not_Proposing_Tools { get; set; }
        public float? Deal_TCV { get; set; }
        public float? Deal_PAT { get; set; }
        public int? Win_Probability { get; set; }
        public int? Overall_Team_Size { get; set; }
        public int? Total_Team_Size { get; set; }
        public string? Mail_List { get; set; }
        public string? Comments { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public DateTime Last_Updated_Date { get; set; }
        public string Last_Updated_By { get; set; }

        public string? Account_List { get; set; }
        public string? Vertical_List { get; set; }
        public string? Status_List { get; set; }
        public string? Geography_Location { get; set; }
    }
}
