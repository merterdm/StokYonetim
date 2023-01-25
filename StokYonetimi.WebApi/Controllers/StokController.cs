using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StokYonetim.BL.Abstract;
using StokYonetim.Entites;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StokYonetimi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StokController : ControllerBase
    {
        private readonly IStokManager stokManager;
        private readonly IValidator<Stok> validator;

        public StokController(IStokManager stokManager, IValidator<Stok> validator)
        {
            this.stokManager = stokManager;
            this.validator = validator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await stokManager.GetAllAsync();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await stokManager.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost()]
        public async Task<int> Post(Stok model)
        {
            ValidationResult valresult = await validator.ValidateAsync(model);

            if (!valresult.IsValid)
            {

            }


            var result = await stokManager.CreateAsync(model);
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
        [HttpPut()]
        public async Task<int> Put(Stok model)
        {
            var sonuc = await stokManager.UpdateAsync(model);
            if (sonuc > 0)
            {
                return StatusCodes.Status202Accepted;
            }
            else
            {
                return StatusCodes.Status501NotImplemented;
            }
        }
        [HttpDelete()]
        public async Task<int> Delete(Stok model)
        {
            var sonuc = await stokManager.DeleteAsync(model);
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
