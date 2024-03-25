using Application.Dto.ChangePassword;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.UserValidator
{
    public class ChangePasswordValidations : AbstractValidator<ChangePasswordDto>
    {

        public ChangePasswordValidations()
        {



            RuleFor(user => user.UserId)
                    .NotEmpty().WithMessage("UserID cannot be empty");
                    

            RuleFor(user => user.CurrentPassword)
                    .NotEmpty().WithMessage("Password can not be empty")
                    .MinimumLength(5).WithMessage("Minimum password length is 5 letters long")
                    .MaximumLength(15).WithMessage("Maximum password length is 15 letters")
                    .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                    .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                    .Matches("[^a-zA-Z0-9]]").WithMessage("Password must contain atleast one special character")
                    .NotEqual("password", StringComparer.OrdinalIgnoreCase)
                    .WithMessage("password cannot be password.");

            RuleFor(user => user.NewPassword)
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
