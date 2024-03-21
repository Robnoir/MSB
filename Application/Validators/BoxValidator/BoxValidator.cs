using Domain.Models.BoxModel;
using FluentValidation;

namespace Application.Validators.BoxValidator
{
    public class BoxValidator : AbstractValidator<BoxModel>
    {
        public BoxValidator()
        {
            RuleFor(box => box.BoxId)
                .NotEmpty().WithMessage("Box ID can't be empty");

            RuleFor(box => box.Type)
                .NotEmpty().WithMessage("Box Type needs specificaton");

            RuleFor(box => box.Size)
                .NotEmpty().WithMessage("Box Size needs to be specified");

            //RuleFor(box => box.Orders)
            //    .NotEmpty().WithMessage("Box needs to be attached to an ID");


        }
    }
}
