using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new AppNotFoundException("Order", request.Id);
            }

            return new GetOrderByIdQueryResult
            {
                Id = order.Id,
                ShippingAddress = order.ShippingAddress,
                AppUserId = order.AppUserId,
                UserName = order.AppUser?.UserName
            };
        }
    }
}
