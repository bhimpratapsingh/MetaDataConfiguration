using System.ComponentModel.DataAnnotations;

namespace MetadataConfigurationAPI.Models
{
    public class EntityConfiguration
    {
        [Key]
        [Required]
        public string EntityName { get; set; }

        public ICollection<FieldConfiguration> Fields { get; set; }

    }
}
