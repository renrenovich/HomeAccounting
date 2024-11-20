using HomeAccounting.Domain.Entities;
using HomeAccounting.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeAccounting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Gets a user by ID",
            Description = "Retrieves the details of a user based on the provided ID.",
            OperationId = "GetUser",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "Returns the user.", typeof(User))]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var user = await _userService.GetAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new user",
            Description = "Creates a new user with the provided details.",
            OperationId = "CreateUser",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "Returns the created user details.", typeof(User))]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> CreateAsync([FromBody] User user)
        {
            try
            {
                var createdUser = await _userService.CreateAsync(user);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}