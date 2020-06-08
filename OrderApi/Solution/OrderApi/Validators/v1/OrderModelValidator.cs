using FluentValidation;
using OrderApi.Models.v1;

namespace OrderApi.Validators.v1
{
    public class OrderModelValidator : AbstractValidator<OrderModel>
    {
        public OrderModelValidator()
        {
            RuleFor(order => order.CustomerFullName)
                .NotNull()
                .WithMessage("The customer name must be at least 2 character long");
            RuleFor(order => order.CustomerFullName)
                .MinimumLength(2).WithMessage("The customer name must be at least 2 character long");
        }
    }
}