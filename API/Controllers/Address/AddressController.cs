using Application.Commands.Address.AddAddress;
using Application.Commands.Address.DeleteAddress;
using Application.Commands.Address.UpdateAddress;
using Application.Dto.Adress;
using Application.Queries.Address.GetAll;
using Application.Queries.Address.GetByID;
using Application.Validators.AddressValidator;
using Domain.Models.Address;
using FluentValidation;
using Infrastructure.Repositories.OrderRepo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Address
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly AddressRepository _addressRepository;
        private readonly AddressValidations _addressValidations;

        public AddressController(IMediator mediator, IConfiguration configuration, AddressRepository addressRepository, AddressValidations validationRules)
        {
            _mediator = mediator;
            _configuration = configuration;
            _addressRepository = addressRepository;
            _addressValidations = validationRules;
        }

        [HttpPost]
        [Route("Add Address")]
        public async Task<ActionResult<AddressDto>> AddAddress(AddAddressCommand command)
        {
            var adressDto = new AddressDto
            {
                StreetName = command.NewAddress.StreetName,
                StreetNumber = command.NewAddress.StreetNumber,
                Apartment = command.NewAddress.Apartment,
                ZipCode = command.NewAddress.ZipCode,
                Floor = command.NewAddress.Floor,
                City = command.NewAddress.City,
                State = command.NewAddress.State,
                Country = command.NewAddress.Country,
            };


            var validationResult = _addressValidations.Validate(adressDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var address = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAddressById), new { id = address.AddressId }, address);
        }

        [HttpGet]
        [Route("Get All Addresses")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAllAddresses()
        {
            var query = new GetAllAddressesQuery();
            var addresses = await _mediator.Send(query);
            return Ok(addresses);
        }

        [HttpGet("Get Address By {id}")]
        public async Task<ActionResult<AddressDto>> GetAddressById(Guid id)
        {
            var query = new GetAddressByIdQuery(id);
            var address = await _mediator.Send(query);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPut("Update Address By {id}")]
        public async Task<IActionResult> UpdateAddress(Guid id, AddressModel address)
        {
            if (id != address.AddressId)
            {
                return BadRequest();
            }

            var command = new UpdateAddressCommand(address);
            var updatedAddress = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("Delete Address By {id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            var command = new DeleteAddressCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}