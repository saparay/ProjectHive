using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjectHive.API.Models
{
    [Table("Vertical_List")]
    public class VerticalList
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Value must not be null"), NotNull, MaxLength(50)]
        public required string Value { get; set; }
        [JsonIgnore]
        // Navigation properties
        public virtual ICollection<ProjectTracker>? ProjectTracker { get; set; }
    }
}
