using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<Result<int>>
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
