using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.Services;

namespace Watch_Store_Management_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var userId =  User.Claims.SingleOrDefault(x => x.Type == "Id");
            var Admin = User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Role);
            if (Admin is not null && Admin.Value.Equals("Admin"))
            {
                var resultForAdmin = await this.orderService.GetAll();
                return Ok(resultForAdmin);
            }
            if (userId is not null){
                var resultForUser = await this.orderService.GetOrderById(Convert.ToInt32(userId.Value));
                return Ok(resultForUser);
            }
            return BadRequest(new { message = "Bad Request"});
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Post(OrderRequestDTO orderRequest)
        {
            var userId = User.Claims.SingleOrDefault(x => x.Type.Equals("Id"));
            if (userId is not null)
            {
                var result = await this.orderService.Add(Convert.ToInt32(userId.Value), orderRequest);
                return Ok(result);
            }return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromQuery] int status)
        {
            var result = await this.orderService.Update(id, status);
            if (result is not null) return Ok(result);
            return NotFound(new { message = $"Entity with ID => {id} Not Found" });
        }

        [HttpDelete]
        [Route("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.orderService.Delete(id);
            if (result) return Ok(new { message = $"Entity with ID => {id} Deleted" });
            return NotFound(new { message = $"Entity with ID => {id} Not Found" });
        }
    }
}
