using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Result>
    {
        private readonly IProductRepository _repository;

        public RemoveProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _repository.GetByIdAsync(request.Id);
                if (product == null)
                {
                    throw new AppNotFoundException("Product", request.Id);
                }

                product.Status = DataStatus.Deleted;
                product.DeletedDate = DateTime.Now;
                await _repository.SaveChangesAsync();
                return Result.Success("Ürün başarıyla silindi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Ürün silinirken bir hata oluştu", ex);
            }
        }
    }
}
