using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.Services;

namespace Watch_Store_Management_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Get()
        {
            var result = await this.addressService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Post(AddressRequestDTO addressRequest)
        {
            var result = await this.addressService.Add(addressRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        // [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetAddressByUserId(int id)
        {
            var result = await this.addressService.GetAddressByUserId(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.addressService.Delete(id);
            if (result) return Ok(new { message = $"Entity with ID => {id} Deleted" });
            return NotFound(new { message = $"Entity with ID => {id} Not Found" });
        }

        [HttpPut]
        [Route("{id}")]
        // [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Update(int id, [FromBody] AddressRequestDTO addressRequest)
        {
            var result = await this.addressService.Update(id, addressRequest);
            if (result is not null) return Ok(result);
            return NotFound(new { message = $"Entity with ID => {id} Not Found" });
        }
    }
}
