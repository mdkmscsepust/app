using App.Application.Interfaces;
using App.Application.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserInDTO user)
        {
            if (await _userService.AddAsync(user))
            {
                return Ok("User added successfully");
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserInDTO user)
        {
            if (await _userService.UpdateAsync(id, user))
            {
                return Ok("User updated successfully");
            }
            return BadRequest();
        }

        [HttpGet("hello")]
        public string Hello()
        {
            return "Hello World from GET endpoint!";
        }
    }
}