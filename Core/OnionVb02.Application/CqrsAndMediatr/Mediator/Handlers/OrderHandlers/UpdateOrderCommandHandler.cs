using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var oldOrder = await _repository.GetByIdAsync(request.Id);
                if (oldOrder == null)
                {
                    throw new AppNotFoundException("Order", request.Id);
                }

                oldOrder.ShippingAddress = request.ShippingAddress;
                oldOrder.AppUserId = request.AppUserId;
                oldOrder.UpdatedDate = DateTime.Now;
                oldOrder.Status = DataStatus.Updated;

                await _repository.UpdateAsync(oldOrder, oldOrder);
                await _repository.SaveChangesAsync();
                return Result.Success("Sipariş başarıyla güncellendi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Sipariş güncellenirken bir hata oluştu", ex);
            }
        }
    }
}
