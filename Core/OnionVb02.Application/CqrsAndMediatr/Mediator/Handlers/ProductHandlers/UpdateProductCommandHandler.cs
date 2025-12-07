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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var oldProduct = await _repository.GetByIdAsync(request.Id);
                if (oldProduct == null)
                {
                    throw new AppNotFoundException("Product", request.Id);
                }

                oldProduct.ProductName = request.ProductName;
                oldProduct.UnitPrice = request.UnitPrice;
                oldProduct.CategoryId = request.CategoryId;
                oldProduct.UpdatedDate = DateTime.Now;
                oldProduct.Status = DataStatus.Updated;

                await _repository.UpdateAsync(oldProduct, oldProduct);
                await _repository.SaveChangesAsync();
                return Result.Success("Ürün başarıyla güncellendi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Ürün güncellenirken bir hata oluştu", ex);
            }
        }
    }
}
