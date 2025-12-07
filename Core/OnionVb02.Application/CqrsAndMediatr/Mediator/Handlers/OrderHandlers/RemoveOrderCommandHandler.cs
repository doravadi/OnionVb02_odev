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
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand, Result>
    {
        private readonly IOrderRepository _repository;

        public RemoveOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _repository.GetByIdAsync(request.Id);
                if (order == null)
                {
                    throw new AppNotFoundException("Order", request.Id);
                }

                order.Status = DataStatus.Deleted;
                order.DeletedDate = DateTime.Now;
                await _repository.SaveChangesAsync();
                return Result.Success("Sipariş başarıyla silindi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Sipariş silinirken bir hata oluştu", ex);
            }
        }
    }
}
