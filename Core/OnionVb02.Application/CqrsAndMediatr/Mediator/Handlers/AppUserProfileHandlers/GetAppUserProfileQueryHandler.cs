using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers
{
    public class GetAppUserProfileQueryHandler : IRequestHandler<GetAppUserProfileQuery, List<GetAppUserProfileQueryResult>>
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppUserProfileQueryResult>> Handle(GetAppUserProfileQuery request, CancellationToken cancellationToken)
        {
            var appUserProfiles = await _repository.GetAllAsync();
            return appUserProfiles.Select(p => new GetAppUserProfileQueryResult
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                AppUserId = p.AppUserId,
                UserName = p.AppUser?.UserName
            }).ToList();
        }
    }
}
