using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify
{
    public class RemoveAppUserCommandHandler : IRequestHandler<RemoveAppUserCommand, Result>
    {
        private readonly IAppUserRepository _repository;

        public RemoveAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appUser = await _repository.GetByIdAsync(request.Id);
                if (appUser == null)
                {
                    throw new AppNotFoundException("AppUser", request.Id);
                }

                await _repository.DeleteAsync(appUser);
                return Result.Success("Kullanıcı başarıyla silindi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Kullanıcı silinirken bir hata oluştu", ex);
            }
        }
    }
}
