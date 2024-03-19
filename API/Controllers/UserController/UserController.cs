using Application.Commands.Users.DeleteUser;
using Application.Commands.Users.UpdateUser;
using Application.Dto.User;
using Application.Queries.User.GetAll;
using Application.Queries.User.GetById;
using Domain.Models.UserModel;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> RegisterAsync([FromBody] UserDto request)
        {


            UserModel newUser = new UserModel()
            {
                UserId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                //PasswordHash = request.Password,
            };

            await _userRepository.AddUserAsync(newUser);
            return newUser;
        }

        //------------------------------------------------------------------------------------

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }



        //------------------------------------------------------------------------------------

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult>GetUserById(Guid UserId)
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
        [Route("updateUser")]
        public async Task<IActionResult> UpdateUser(Guid id,[FromBody] UserDto updatedUserDto)
        {
            try
            {
                var command = new UpdateUserCommand(updatedUserDto, id);
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
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An Error occurred:{ex.Message}");
            }
        }

        //------------------------------------------------------------------------------------

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            var user = await _mediator.Send(new DeleteUserCommand( id));

            if(user == null)
            {
                return NoContent();
            }

            return NotFound();

        }

        //------------------------------------------------------------------------------------





    }
}
