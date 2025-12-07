using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;

namespace OnionVb02.ValidatorStructor.Validators.OrderDetailValidators
{
    public class UpdateOrderDetailCommandValidator : AbstractValidator<UpdateOrderDetailCommand>
    {
        public UpdateOrderDetailCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir ID girilmelidir");

            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Geçerli bir sipariş seçilmelidir");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün seçilmelidir");
        }
    }
}
