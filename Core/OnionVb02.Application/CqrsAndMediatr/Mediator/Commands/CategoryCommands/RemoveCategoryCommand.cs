using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
