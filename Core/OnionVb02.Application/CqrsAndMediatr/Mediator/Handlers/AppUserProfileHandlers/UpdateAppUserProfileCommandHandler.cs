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
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommand, Result>
    {
        private readonly IAppUserProfileRepository _repository;

        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var oldAppUserProfile = await _repository.GetByIdAsync(request.Id);
                if (oldAppUserProfile == null)
                {
                    throw new AppNotFoundException("AppUserProfile", request.Id);
                }

                oldAppUserProfile.FirstName = request.FirstName;
                oldAppUserProfile.LastName = request.LastName;
                oldAppUserProfile.AppUserId = request.AppUserId;
                oldAppUserProfile.UpdatedDate = DateTime.Now;
                oldAppUserProfile.Status = DataStatus.Updated;

                await _repository.UpdateAsync(oldAppUserProfile, oldAppUserProfile);
                await _repository.SaveChangesAsync();
                return Result.Success("Kullanıcı profili başarıyla güncellendi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Kullanıcı profili güncellenirken bir hata oluştu", ex);
            }
        }
    }
}
