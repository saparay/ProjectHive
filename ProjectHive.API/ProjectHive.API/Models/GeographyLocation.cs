using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjectHive.API.Models
{
    [Table("Geography_Location")]
    public class GeographyLocation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Value must not be null"), NotNull, MaxLength(50)]
        public required string Value { get; set; }

        //Navigations
        [JsonIgnore]
        public virtual ICollection<ProjectTracker>? ProjectTrackers { get; set; }
    }
}
