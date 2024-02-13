using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.Services;

namespace Watch_Store_Management_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.productService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this.productService.GetById(id);
            if (result is not null) return Ok(result);
            return NotFound(new { message = $"Entity with ID => {id} Not Found" });
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestDTO productRequestDTO)
        {
            try
            {
                var result = await this.productService.Add(productRequestDTO);
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("Error", "Category or Brand ID not found");
                return BadRequest(ModelState);
                //return Problem(title: "Error", detail: $"Category with id {productRequestDTO.CategoryId} not found", statusCode: 400);
            }
        }

    }
}
