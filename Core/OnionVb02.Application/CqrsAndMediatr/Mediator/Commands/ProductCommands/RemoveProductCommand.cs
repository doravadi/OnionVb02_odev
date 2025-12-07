using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class RemoveProductCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
