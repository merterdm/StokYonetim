using Microsoft.AspNetCore.Mvc;

namespace StokYonetim.WebUI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
