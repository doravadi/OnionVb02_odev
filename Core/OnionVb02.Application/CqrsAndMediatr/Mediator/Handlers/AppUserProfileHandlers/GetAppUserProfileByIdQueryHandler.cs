using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers
{
    public class GetAppUserProfileByIdQueryHandler : IRequestHandler<GetAppUserProfileByIdQuery, GetAppUserProfileByIdQueryResult>
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileByIdQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserProfileByIdQueryResult> Handle(GetAppUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var appUserProfile = await _repository.GetByIdAsync(request.Id);
            if (appUserProfile == null)
            {
                throw new AppNotFoundException("AppUserProfile", request.Id);
            }

            return new GetAppUserProfileByIdQueryResult
            {
                Id = appUserProfile.Id,
                FirstName = appUserProfile.FirstName,
                LastName = appUserProfile.LastName,
                AppUserId = appUserProfile.AppUserId,
                UserName = appUserProfile.AppUser?.UserName
            };
        }
    }
}
