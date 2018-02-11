using AzureKeyVaultAspNetCore.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AzureKeyVaultAspNetCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ValueSettings _valueSettings;

        public ValuesController(IOptions<ValueSettings> valueSettings)
        {
            _valueSettings = valueSettings.Value;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_valueSettings.TestSecret);
        }
    }
}
