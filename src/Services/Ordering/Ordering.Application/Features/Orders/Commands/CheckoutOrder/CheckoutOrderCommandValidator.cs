using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(command => command.UserName)
            .NotEmpty().WithMessage("{UserName} cannot be empty")
            .NotNull()
            .MaximumLength(50).WithMessage("{UserName} cannot be longer than 50 characters");

            RuleFor(command => command.EmailAddress)
            .NotEmpty().WithMessage("{EmailAddress} cannot be empty");

            RuleFor(command => command.TotalPrice)
            .NotEmpty().WithMessage("{TotalPrice} cannot be empty")
            .GreaterThan(0).WithMessage("{TotalPrice} cannot be less than 0");

        }
    }
}
