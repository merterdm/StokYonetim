using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using StokYonetim.BL.Abstract;

namespace OdataWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ODataController
    {
        private readonly IKategoriManager manager;

        public KategoriController(IKategoriManager manager)
        {
            this.manager = manager;
        }



        [EnableQuery(PageSize = 20)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await manager.GetAllAsync();
            return Ok(result);
        }

        [EnableQuery(PageSize = 20)]
        [HttpGet]
        public async Task<IActionResult> GetById([FromODataUri] int id)
        {
            var result = await manager.GetByIdAsync(id);
            return Ok(result);
        }

    }
}
