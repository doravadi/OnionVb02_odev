using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class CreateOrderDetailCommand : IRequest<Result<int>>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
