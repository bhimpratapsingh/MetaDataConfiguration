using MetaDataConfiguration.Shared.Helpers;
using MetadataConfigurationAPI.Models;
using MetadataConfigurationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace MetadataConfigurationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IEntityFieldConfigurationService _configurationService;
        private readonly HttpClient _httpClient;
        public ConfigurationController(IEntityFieldConfigurationService configurationService, HttpClient httpClient)
        {
            _configurationService = configurationService;
            _httpClient = httpClient;
        }

        // GET: api/<ConfigurationController>
        /// <summary>
        /// Get all the configuration after merging the data from Source1 and Source2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                //Source1
                string defaultFieldUrl = $"{Request.Scheme}://{Request.Host}/api/DefaultFields/{id}";
                var tempDefaultFieldResult = new HttpClientHelper(_httpClient).GetResponse(defaultFieldUrl);
                var defaultFieldResult = JsonSerializer.Deserialize<string[]>(tempDefaultFieldResult);

                //Source2
                string customFieldUrl = $"{Request.Scheme}://{Request.Host}/api/CustomFields/{id}";
                var tempCustomFieldResult = new HttpClientHelper(_httpClient).GetResponse(customFieldUrl);
                var customFieldResult = JsonSerializer.Deserialize<string[]>(tempCustomFieldResult);

                var result = (await _configurationService.Get()).Where(x => x.EntityName.ToLower() == id.ToLower()).FirstOrDefault();

                if (result == null)
                {
                    return NotFound();
                }

                List<object> output = new();

                if (defaultFieldResult != null)
                {
                    output.AddRange(result.Fields.Where(x => defaultFieldResult.Contains(x.FieldName, StringComparer.InvariantCultureIgnoreCase)).Select(x => new
                    {
                        Field = x.FieldName,
                        x.IsRequired,
                        x.MaxLength,
                        Source = "Source1"

                    }).ToList());

                }

                if (customFieldResult != null)
                {
                    output.AddRange(result.Fields.Where(x => customFieldResult.Contains(x.FieldName, StringComparer.InvariantCultureIgnoreCase)).Select(x => new
                    {
                        Field = x.FieldName,
                        x.IsRequired,
                        x.MaxLength,
                        Source = "Source2"

                    }).ToList());
                }

                var res = new { EntityName = id, Fields = output };

                return Ok(new[] { res });
            }
            catch (Exception)
            {
                //log error before returning
                return Problem();
            }
        }

        // POST api/<ConfigurationController>
        /// <summary>
        /// Save the entity field configuration data
        /// </summary>
        /// <param name="entityFields"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<EntityConfiguration> entityFields)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _configurationService.Save(entityFields))
                    {
                        return Ok();
                    }
                    else
                    {
                        return Problem("Save failed", null, (int)HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    return ValidationProblem(ModelState);
                }
            }
            catch (Exception)
            {
                //log error before returning
                return Problem();
            }
        }
    }
}
