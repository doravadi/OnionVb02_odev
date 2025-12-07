using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class RemoveOrderCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
