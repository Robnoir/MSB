using Application.Dto.User;
using Domain.Models;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UserController
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserController(IMediator mediator, IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _mediator = mediator;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterAsync([FromBody] UserDto request)
        {


            User newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
            };

            await _userRepository.AddUserAsync(newUser);
            return newUser;
        }



    }
}
