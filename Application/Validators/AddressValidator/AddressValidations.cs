using Application.Dto.Adress;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.AddressValidator
{
    public class AddressValidations : AbstractValidator<AddressDto>
    {
        public AddressValidations()
        {
            RuleFor(address => address.StreetName)
           .NotEmpty().WithMessage("Street name is required.")
           .Length(1, 100).WithMessage("Street name must be between 1 and 100 characters long.");

            RuleFor(address => address.StreetNumber)
                .NotEmpty().WithMessage("Street number is required.")
                .Matches(@"^\d+\w*$").WithMessage("Street number must be a valid number, optionally followed by a letter.");

            RuleFor(address => address.Apartment)
                .NotEmpty().WithMessage("Apartment number is required.")
                .Matches(@"^\w+$").WithMessage("Apartment number must be a valid alphanumeric string.");

            RuleFor(address => address.ZipCode)
                .NotEmpty().WithMessage("Zip code is required.");
            //.Matches(@"^\d{5}(-\d{4})?$").WithMessage("Zip code must be a valid ZIP code (U.S. format)."); // Adjust regex for local format if necessary

            RuleFor(address => address.Floor)
                .NotEmpty().WithMessage("Floor is required.")
                .Matches(@"^[a-zA-Z0-9]+$").WithMessage("Floor must be alphanumeric.");

            RuleFor(address => address.City)
                .NotEmpty().WithMessage("City is required.")
                .Length(1, 50).WithMessage("City must be between 1 and 50 characters long.");

            RuleFor(address => address.State)
                .NotEmpty().WithMessage("State is required.")
                .Length(1, 50).WithMessage("State must be between 1 and 50 characters long.");

            RuleFor(address => address.Country)
                .NotEmpty().WithMessage("Country is required.")
                .Length(1, 50).WithMessage("Country must be between 1 and 50 characters long.");

            //RuleFor(address => address.Latitude)
            //    .InclusiveBetween(-90.0, 90.0).WithMessage("Latitude must be between -90 and 90.");

            //RuleFor(address => address.Longitude)
            //    .InclusiveBetween(-180.0, 180.0).WithMessage("Longitude must be between -180 and 180.");


        }

    }
}
