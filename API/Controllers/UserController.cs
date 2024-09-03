using Application.UseCase.Users.Register;
using Communication.Requests;
using Communication.Responses;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;


        public UserController(UserDbContext context)
        {
            _registerUserUseCase = new RegisterUserUseCase(context);
        }


        [HttpPost("register")]
        [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {
            try
            {
                var response = _registerUserUseCase.Execute(request);
                return CreatedAtAction(nameof(Register), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
