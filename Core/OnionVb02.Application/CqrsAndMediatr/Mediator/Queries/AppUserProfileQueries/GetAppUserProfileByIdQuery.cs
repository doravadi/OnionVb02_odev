using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries
{
    public class GetAppUserProfileByIdQuery : IRequest<GetAppUserProfileByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
