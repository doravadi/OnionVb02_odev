using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand, Result<int>>
    {
        private readonly IAppUserProfileRepository _repository;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appUserProfile = new AppUserProfile
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    AppUserId = request.AppUserId,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                await _repository.CreateAsync(appUserProfile);
                return Result<int>.Success(appUserProfile.Id, "Kullanıcı profili başarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Kullanıcı profili oluşturulurken bir hata oluştu", ex);
            }
        }
    }
}
