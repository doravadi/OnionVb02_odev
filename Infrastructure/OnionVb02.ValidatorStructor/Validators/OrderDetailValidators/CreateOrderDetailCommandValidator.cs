using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;

namespace OnionVb02.ValidatorStructor.Validators.OrderDetailValidators
{
    public class CreateOrderDetailCommandValidator : AbstractValidator<CreateOrderDetailCommand>
    {
        public CreateOrderDetailCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Geçerli bir sipariş seçilmelidir");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün seçilmelidir");
        }
    }
}
