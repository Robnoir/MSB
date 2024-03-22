using Application.Commands.Users.DeleteUser;
using Application.Commands.Users.UpdateUser;
using Application.Dto.User;
using Application.Queries.User.GetAll;
using Application.Queries.User.GetById;
using Infrastructure.Repositories.UserRepo;
using MediatR;
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
        //------------------------------------------------------------------------------------

        [HttpGet]
        [Route("Get all users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

        //------------------------------------------------------------------------------------

        [HttpGet]
        [Route("GetUser by Id")]
        public async Task<IActionResult> GetUserById(Guid UserId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetUserByIdQuery(UserId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------------------------------------------------------------------------------------
        [HttpPut]
        [Route("(Update User")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto updatedUserDto, Guid updatedUserId)
        {
            try
            {
                var command = new UpdateUserCommand(updatedUserDto, updatedUserId);
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    return NotFound("User not found");
                }

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An Error occurred:{ex.Message}");
            }
        }

        //------------------------------------------------------------------------------------

        [HttpDelete("Delete User by {id}")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            var user = await _mediator.Send(new DeleteUserCommand(id));

            if (user == null)
            {
                return NoContent();
            }
            return NotFound();
        }
        //------------------------------------------------------------------------------------
    }
}
