using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
    {
        private readonly IOrderDetailRepository _repository;

        public GetOrderDetailQueryHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _repository.GetAllAsync();
            return orderDetails.Select(od => new GetOrderDetailQueryResult
            {
                Id = od.Id,
                OrderId = od.OrderId,
                ProductId = od.ProductId,
                ProductName = od.Product?.ProductName,
                OrderAddress = od.Order?.ShippingAddress
            }).ToList();
        }
    }
}
