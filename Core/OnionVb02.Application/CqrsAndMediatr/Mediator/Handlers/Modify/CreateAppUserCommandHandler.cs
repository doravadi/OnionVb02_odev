using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using AppDatabaseException = OnionVb02.Application.ErrorManagement.Exceptions.DatabaseException;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;
using AppValidationException = OnionVb02.Application.ErrorManagement.Exceptions.ValidationException;
using OnionVb02.Application.ErrorManagement.Results;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, Result<int>>
    {
        private readonly IAppUserRepository _repository;

        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appUser = new AppUser
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                await _repository.CreateAsync(appUser);
                return Result<int>.Success(appUser.Id, "Kullanıcı başarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                throw new AppDatabaseException("Kullanıcı oluşturulurken bir hata oluştu", ex);
            }
        }
    }
}
