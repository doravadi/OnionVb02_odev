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
    public class RemoveOrderDetailCommandHandler : IRequestHandler<RemoveOrderDetailCommand, Result>
    {
        private readonly IOrderDetailRepository _repository;

        public RemoveOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var orderDetail = await _repository.GetByIdAsync(request.Id);
                if (orderDetail == null)
                {
                    throw new AppNotFoundException("OrderDetail", request.Id);
                }

                orderDetail.Status = DataStatus.Deleted;
                orderDetail.DeletedDate = DateTime.Now;
                await _repository.SaveChangesAsync();
                return Result.Success("Sipariş detayı başarıyla silindi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Sipariş detayı silinirken bir hata oluştu", ex);
            }
        }
    }
}
