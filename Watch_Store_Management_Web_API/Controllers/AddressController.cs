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
        public async Task<IActionResult> Get()
        {
            var result = await this.addressService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddressRequestDTO addressRequest)
        {
            var result = await this.addressService.Add(addressRequest);
            return Ok(result);
        }
    }
}
