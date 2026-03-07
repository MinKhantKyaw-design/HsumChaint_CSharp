using HsumChaint.Application.DTOs;
using HsumChaint.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace HsumChaint.API.Controllers
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
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUsersAsync();
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            return NotFound(response); // Standard REST usually returns 404 if not found
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDto reqModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.AddUser(reqModel);
            if (response.IsSuccess == true)
            {
                // In a true REST API, we'd probably want to return CreatedAtAction, but keeping it standard for now
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto reqModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.UpdateUserAsync(id, reqModel);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUserAsync(id);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
