using MediatR;
using OnionVb02.Application.ErrorManagement.Results;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<Result<int>>
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}
