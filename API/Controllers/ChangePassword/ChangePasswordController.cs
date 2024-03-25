using Application.Commands.Users.ChangePassword;
using Application.Dto.ChangePassword;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ChangePassword
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {

        private readonly IMediator _mediator;

        private readonly IConfiguration _configuration;
        public ChangePasswordController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;

        }


        [HttpPut]
        [Route("Change Password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            try
            {
                var command = new ChangePasswordCommand(changePasswordDto.UserId, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
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
