using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.ProductHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly IProductRepository _repository;

        public GetProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new GetProductQueryResult
            {
                Id = p.Id,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.CategoryName
            }).ToList();
        }
    }
}
