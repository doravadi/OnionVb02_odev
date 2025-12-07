using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
