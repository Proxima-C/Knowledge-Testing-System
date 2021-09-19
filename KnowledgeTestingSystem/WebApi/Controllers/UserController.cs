using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            IEnumerable<UserDTO> users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(string id)
        {
            UserDTO user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserDTO user)
        {
            await _userService.AddAsync(user);
            return Ok("User created successfully.");
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update([FromBody] UserDTO user)
        {
            await _userService.UpdateAsync(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteByIdAsync(id);
            return Ok("User deleted successfully.");
        }
    }
}
