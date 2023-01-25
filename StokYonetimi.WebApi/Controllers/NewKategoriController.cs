using Microsoft.AspNetCore.Mvc;
using StokYonetim.BL.Abstract;
using StokYonetim.Entites;
using StokYonetimi.WebApi.Models;

namespace StokYonetimi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewKategoriController<T> : StokYonetimControllerBase<Kategori>
        where T : Kategori, new()

    {
        private readonly IManagerBase<T> managerBase;

        public NewKategoriController(IManagerBase<T> managerBase) : base((IManagerBase<Kategori>)managerBase)
        {
            this.managerBase = managerBase;
        }
    }
}
