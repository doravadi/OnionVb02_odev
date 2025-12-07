using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var oldCategory = await _repository.GetByIdAsync(request.Id);
                if (oldCategory == null)
                {
                    throw new AppNotFoundException("Category", request.Id);
                }

                oldCategory.CategoryName = request.CategoryName;
                oldCategory.Description = request.Description;
                oldCategory.UpdatedDate = DateTime.Now;
                oldCategory.Status = DataStatus.Updated;

                await _repository.UpdateAsync(oldCategory, oldCategory);
                await _repository.SaveChangesAsync();
                return Result.Success("Kategori başarıyla güncellendi");
            }
            catch (AppNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Kategori güncellenirken bir hata oluştu", ex);
            }
        }
    }
}
