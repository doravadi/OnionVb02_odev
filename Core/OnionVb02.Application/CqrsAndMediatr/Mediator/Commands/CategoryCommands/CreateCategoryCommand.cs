using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<Result<int>>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
