using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers
{
    public class RemoveAppUserProfileCommandHandler : IRequestHandler<RemoveAppUserProfileCommand, Result>
    {
        private readonly IAppUserProfileRepository _repository;

        public RemoveAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appUserProfile = await _repository.GetByIdAsync(request.Id);
                if (appUserProfile == null)
                {
                    throw new AppNotFoundException("AppUserProfile", request.Id);
                }

                appUserProfile.Status = DataStatus.Deleted;
                appUserProfile.DeletedDate = DateTime.Now;
                await _repository.SaveChangesAsync();
                return Result.Success("Kullanıcı profili başarıyla silindi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Kullanıcı profili silinirken bir hata oluştu", ex);
            }
        }
    }
}
