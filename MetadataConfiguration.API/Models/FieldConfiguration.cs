using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MetadataConfigurationAPI.Models
{
    public class FieldConfiguration
    {
        [Key]
        [JsonIgnore]
        public int FieldId { get; set; }

        [Required]
        [JsonPropertyName("Field")]
        public string FieldName { get; set; }

        [Required]
        public bool IsRequired { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int MaxLength { get; set; }
    }
}
