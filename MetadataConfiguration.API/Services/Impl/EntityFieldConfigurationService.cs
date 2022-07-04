using MetadataConfigurationAPI.Data;
using MetadataConfigurationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadataConfigurationAPI.Services.Impl
{
    public class EntityFieldConfigurationService : IEntityFieldConfigurationService
    {
        private readonly ConfigurationContext _context;
        public EntityFieldConfigurationService(ConfigurationContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<List<EntityConfiguration>> Get()
        {
            return await _context.Entities.Include(x => x.Fields).ToListAsync();
        }

        /// <inheritdoc cref="EntityConfiguration"/>
        public async Task<bool> Save(List<EntityConfiguration> entityFields)
        {
            foreach (var entity in entityFields)
            {
                if (_context.Entities.Where(x => x.EntityName == entity.EntityName).Any())
                {
                    foreach (var field in entity.Fields)
                    {
                        if (_context.Entities.Include(x => x.Fields).Where(x => x.EntityName == entity.EntityName && x.Fields.Any(x => x.FieldName == field.FieldName)).Count() > 0)
                        {
                            var result = _context.Fields.Where(x => x.FieldName == field.FieldName).FirstOrDefault();
                            result.IsRequired = field.IsRequired;
                            result.MaxLength = field.MaxLength;
                        }
                        else
                        {
                            var result = _context.Entities.Where(x => x.EntityName == entity.EntityName).FirstOrDefault();
                            result.Fields = new List<FieldConfiguration>();
                            result.Fields.Add(field);
                        }
                    }
                }
                else
                {
                    _context.Entities.Add(entity);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
