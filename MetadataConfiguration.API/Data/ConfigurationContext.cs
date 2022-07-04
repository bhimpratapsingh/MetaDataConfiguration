using MetadataConfigurationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadataConfigurationAPI.Data
{
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options) : base(options)
        {

        }

        public DbSet<EntityConfiguration> Entities { get; set; }
        public DbSet<FieldConfiguration> Fields { get; set; }
    }
}
