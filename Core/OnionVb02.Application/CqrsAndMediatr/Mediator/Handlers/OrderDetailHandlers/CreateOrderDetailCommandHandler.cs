using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, Result<int>>
    {
        private readonly IOrderDetailRepository _repository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = request.OrderId,
                    ProductId = request.ProductId,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                await _repository.CreateAsync(orderDetail);
                return Result<int>.Success(orderDetail.Id, "Sipariş detayı başarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Sipariş detayı oluşturulurken bir hata oluştu", ex);
            }
        }
    }
}
