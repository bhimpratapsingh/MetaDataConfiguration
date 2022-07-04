using MetadataConfigurationAPI.Models;

namespace MetadataConfigurationAPI.Services
{
    public interface IEntityFieldConfigurationService
    {
        /// <summary>
        /// fetch all configuration from database
        /// </summary>
        /// <returns></returns>
        Task<List<EntityConfiguration>> Get();

        /// <summary>
        /// Save configuration to database
        /// </summary>
        /// <param name="fields">Field configuration details with respect to entity</param>
        /// <returns></returns>
        Task<bool> Save(List<EntityConfiguration> entityFields);
    }
}
