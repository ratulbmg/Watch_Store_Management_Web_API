using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.Services;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository;

namespace Watch_Store_Management_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.brandService.GetAll();

            //ModelState.AddModelError("Error", "The input is invalid");
            //return BadRequest(ModelState);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BrandRequestDTO brandRequestDTO)
        {
            var result = await this.brandService.Add(brandRequestDTO);
            return Ok(result);
        }
    }
}
