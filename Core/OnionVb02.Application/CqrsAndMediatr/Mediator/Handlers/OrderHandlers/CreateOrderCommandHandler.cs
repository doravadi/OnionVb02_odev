using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<int>>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = new Order
                {
                    ShippingAddress = request.ShippingAddress,
                    AppUserId = request.AppUserId,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                await _repository.CreateAsync(order);
                return Result<int>.Success(order.Id, "Sipariş başarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Sipariş oluşturulurken bir hata oluştu", ex);
            }
        }
    }
}
