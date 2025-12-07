using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands
{
    public class CreateAppUserCommand : IRequest<Result<int>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
