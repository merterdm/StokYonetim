using Microsoft.AspNetCore.Mvc;
using StokYonetim.BL.Abstract;
using StokYonetim.Entites;
using System.Net;

namespace StokYonetimi.WebApi.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokYonetimControllerBase<T> : ControllerBase
        where T : BaseEntity, new()

    {
        private readonly IManagerBase<T> managerBase;

        public StokYonetimControllerBase(IManagerBase<T> managerBase) : base()
        {
            this.managerBase = managerBase;
        }
        [HttpGet("[action]")]
        public async Task<T> GetById(int id)
        {
            var result = await managerBase.GetByIdAsync(id);
            return result;
        }
        [HttpGet("[action]")]
        public async Task<ICollection<T>> GetAll()
        {
            var result = await managerBase.GetAllAsync();
            return result;
        }

        [HttpPost("[action]")]
        public async Task<int> PostAsync(T model)
        {


            var result = await managerBase.CreateAsync(model);
            if (result == null)
            {
                return (int)HttpStatusCode.NotFound;
            }
            else if (result == 0)
            {
                return (int)HttpStatusCode.NotImplemented;
            }
            return (int)HttpStatusCode.OK;
        }

        [HttpPut("[action]")]
        public async Task<int> PutAsync(T model)
        {
            var sonuc = await managerBase.UpdateAsync(model);
            if (sonuc > 0)
            {
                return StatusCodes.Status202Accepted;
            }
            else
            {
                return StatusCodes.Status501NotImplemented;
            }
        }
        [HttpDelete("[action]")]
        public async Task<int> DeleteAsync(T model)
        {
            var sonuc = await managerBase.DeleteAsync(model);
            if (sonuc > 0)
            {
                return StatusCodes.Status202Accepted;
            }
            else
            {
                return StatusCodes.Status204NoContent;
            }
        }
    }
}
