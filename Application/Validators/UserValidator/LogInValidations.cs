using Application.Dto.LogIn;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.UserValidator
{
    public class LogInValidations : AbstractValidator<LogInDto>
    {

        public LogInValidations()
        {

            RuleFor(user => user.Email)
                    .NotEmpty().WithMessage("Email cannot be empty")
                    .MaximumLength(10).WithMessage("Email cant be longer than 10 letters")
                    .MinimumLength(5).WithMessage("Email minimum lenth 5 letters")
                    .Matches("^[a-zA-Z0-9_-]+$").WithMessage("Email can only contain letters, numbers, underscores, and hyphens.");

            RuleFor(user => user.Password)
                    .NotEmpty().WithMessage("Password can not be empty")
                    .MinimumLength(5).WithMessage("Minimum password length is 5 letters long")
                    .MaximumLength(15).WithMessage("Maximum password length is 15 letters")
                    .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                    .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                    .Matches("[^a-zA-Z0-9]]").WithMessage("Password must contain atleast one special character")
                    .NotEqual("password", StringComparer.OrdinalIgnoreCase)
                    .WithMessage("password cannot be password.");


        }



    }
}
