using Application.Commands.Users.LogIn;
using Application.Dto.LogIn;
using Application.Dto.Register;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterLoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public RegisterLoginController(IMediator mediator, IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _mediator = mediator;
            _userRepository = userRepository;
        }
        //------------------------------------------------------------------------------------

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var command = new AddUserCommand(registerDto);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //------------------------------------------------------------------------------------

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LogInDto logInDto)
        {
            try
            {
                var command = new UserLoginCommand(logInDto);
                var user = await _mediator.Send(command);

                if (user != null)
                {
                    return Ok(new { Message = "Login Successful" });
                }
                else
                {
                    return Unauthorized(new { Message = "Invalid Email or Password" });
                }

            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "User not found" });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { Message = "Invalid Email or Password" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }





    }
}
