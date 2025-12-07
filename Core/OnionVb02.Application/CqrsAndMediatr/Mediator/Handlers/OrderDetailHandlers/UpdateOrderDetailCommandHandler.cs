using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, Result>
    {
        private readonly IOrderDetailRepository _repository;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var oldOrderDetail = await _repository.GetByIdAsync(request.Id);
                if (oldOrderDetail == null)
                {
                    throw new AppNotFoundException("OrderDetail", request.Id);
                }

                oldOrderDetail.OrderId = request.OrderId;
                oldOrderDetail.ProductId = request.ProductId;
                oldOrderDetail.UpdatedDate = DateTime.Now;
                oldOrderDetail.Status = DataStatus.Updated;

                await _repository.UpdateAsync(oldOrderDetail, oldOrderDetail);
                await _repository.SaveChangesAsync();
                return Result.Success("Sipariş detayı başarıyla güncellendi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Sipariş detayı güncellenirken bir hata oluştu", ex);
            }
        }
    }
}
