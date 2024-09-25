using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjectHive.API.Models
{
    [Table("Technology_Framework")]
    public class TechnologyFramework
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Value must not be null"), NotNull, MaxLength(50)]
        public required string Value { get; set; }
    }
}
