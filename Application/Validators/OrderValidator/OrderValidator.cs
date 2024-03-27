using Domain.Models.Order;
using FluentValidation;

namespace Application.Validators.OrderValidator
{
    public class OrderValidator : AbstractValidator<OrderModel>
    {
        public OrderValidator()
        {
            RuleFor(order => order.OrderId)
                .NotEmpty().WithMessage("Order Id cannot be empty");

            RuleFor(order => order.OrderDate)
                .NotEmpty().WithMessage("Order Date cannot be empty");

            RuleFor(order => order.TotalCost)
                .NotEmpty().WithMessage("Total Cost cannot be empty")
                .GreaterThan(0).WithMessage("Total Cost must be greater than 0");

            RuleFor(order => order.OrderStatus)
                .NotEmpty().WithMessage("Order Status cannot be empty")
                .MaximumLength(50).WithMessage("Order Status can't be longer than 50 characters");

            RuleFor(order => order.UserId)
                .NotEmpty().WithMessage("User Id cannot be empty");

            //RuleFor(order => order.AdressId)
            //    .NotEmpty().WithMessage("Address Id cannot be empty");

            RuleFor(order => order.RepairNotes)
                .MaximumLength(200).WithMessage("Repair Notes can't be longer than 200 characters");
        }
    }
}
