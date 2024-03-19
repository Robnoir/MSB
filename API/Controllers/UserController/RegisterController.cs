using Application.Dto.Register;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public RegisterController(IMediator mediator, IConfiguration configuration, IUserRepository userRepository)
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
    }
}
