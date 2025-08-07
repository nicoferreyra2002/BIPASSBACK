using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Entities;

namespace BIPASS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };

            var created = await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }

        public class CreateUserRequest
        {
            public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}

