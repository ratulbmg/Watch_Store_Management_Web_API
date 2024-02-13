using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.Services;

namespace Watch_Store_Management_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryServices;
        public CategoryController(ICategoryService categoryServices)
        {
            this.categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.categoryServices.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryRequestDTO categoryRequestDTO)
        {
            var result = await this.categoryServices.Add(categoryRequestDTO);
            return Ok(result);
        }
    }
}
