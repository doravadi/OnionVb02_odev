using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, Result>
    {
        private readonly IAppUserRepository _repository;

        public UpdateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appUser = await _repository.GetByIdAsync(request.Id);
                if (appUser == null)
                {
                    throw new AppNotFoundException("AppUser", request.Id);
                }

                appUser.UserName = request.UserName;
                appUser.Password = request.Password;
                appUser.Status = DataStatus.Updated;
                appUser.UpdatedDate = DateTime.Now;

                await _repository.SaveChangesAsync();
                return Result.Success("Kullanıcı başarıyla güncellendi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Kullanıcı güncellenirken bir hata oluştu", ex);
            }
        }
    }
}
