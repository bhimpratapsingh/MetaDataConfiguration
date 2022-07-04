using Microsoft.AspNetCore.Mvc;

namespace MetadataConfigurationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldsController : ControllerBase
    {
        // GET: api/<CustomFields>/Product
        [HttpGet("{id}")]
        public IEnumerable<string> Get(string id)
        {
            if (string.Equals(id, "product", StringComparison.InvariantCultureIgnoreCase))
            {
                return new string[] { "CField1", "CField2" };
            }
            else if (string.Equals(id, "product2", StringComparison.InvariantCultureIgnoreCase))
            {
                return new string[] { "CField3", "CField4" };
            }
            else
            {
                return Array.Empty<string>();
            }
        }
    }
}
