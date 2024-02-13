using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Request;
using Watch_Store_Management_Web_API.BusinessLogicLayer.Services;

namespace Watch_Store_Management_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.userService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this.userService.GetById(id);
            if (result is not null)  return Ok(result);
            return NotFound(new { message = $"Entity with ID => {id} Not Found" });
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRequestDTO userRequest)
        {
            var result = await this.userService.Add(userRequest);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserRequestDTO userRequest)
        {
            var result = await this.userService.Update(id, userRequest);
            if (result is not null) return Ok(result);
            return NotFound(new { message = $"Entity with ID => {id} Not Found" });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.userService.Delete(id);
            if (result) return Ok(new { message = $"Entity with ID => {id} Deleted"});
            return NotFound(new { message = $"Entity with ID => {id} Not Found" });
        }
    }
}
