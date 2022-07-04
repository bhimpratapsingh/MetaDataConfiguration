using Microsoft.AspNetCore.Mvc;

namespace MetadataConfigurationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultFieldsController : ControllerBase
    {
        // GET: api/<DefaultFields>/Product
        [HttpGet("{id}")]
        public IEnumerable<string> Get(string id)
        {
            if (string.Equals(id, "product", StringComparison.InvariantCultureIgnoreCase))
            {
                return new string[] { "Field1", "Field2" };
            }
            else if (string.Equals(id, "product2", StringComparison.InvariantCultureIgnoreCase))
            {
                return new string[] { "Field3", "Field4" };
            }
            else
            {
                return Array.Empty<string>();
            }
        }
    }
}
