using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class RemoveAppUserProfileCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
