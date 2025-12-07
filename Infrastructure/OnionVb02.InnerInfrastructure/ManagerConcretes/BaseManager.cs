using AutoMapper;
using OnionVb02.Application.DTOInterfaces;
using OnionVb02.Application.Helpers;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Interfaces;
using AppNotFoundException = OnionVb02.Application.ErrorManagement.Exceptions.NotFoundException;
using AppBusinessException = OnionVb02.Application.ErrorManagement.Exceptions.BusinessException;

namespace OnionVb02.InnerInfrastructure.ManagerConcretes
{
    public abstract class BaseManager<T, U> : IManager<T, U> where T : class, IDto where U : class, IEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        public BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(T entity)
        {
            await ErrorHandlerHelper.ExecuteWithErrorHandling(async () =>
            {
                U domainEntity = _mapper.Map<U>(entity);
                domainEntity.CreatedDate = DateTime.Now;
                domainEntity.Status = Domain.Enums.DataStatus.Inserted;

                await _repository.CreateAsync(domainEntity);
            }, "CreateAsync");
        }

        public List<T> GetActives()
        {
            List<U> values = _repository.Where(x => x.Status != Domain.Enums.DataStatus.Deleted).ToList();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await ErrorHandlerHelper.ExecuteWithErrorHandling(async () =>
            {
                List<U> values = await _repository.GetAllAsync();
                return _mapper.Map<List<T>>(values);
            }, "GetAllAsync");
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await ErrorHandlerHelper.ExecuteWithErrorHandling(async () =>
            {
                U value = await _repository.GetByIdAsync(id);
                if (value == null)
                {
                    throw new AppNotFoundException(typeof(U).Name, id);
                }
                return _mapper.Map<T>(value);
            }, "GetByIdAsync");
        }

        public List<T> GetPassives()
        {
            List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Deleted).ToList();
            return _mapper.Map<List<T>>(values);
        }

        public List<T> GetUpdateds()
        {
            List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Updated).ToList();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            return await ErrorHandlerHelper.ExecuteWithErrorHandling(async () =>
            {
                U value = await _repository.GetByIdAsync(id);
                if (value == null)
                {
                    throw new AppNotFoundException(typeof(U).Name, id);
                }
                if (value.Status != Domain.Enums.DataStatus.Deleted)
                {
                    throw new AppBusinessException("Veri silinebilmesi için pasif olmalı");
                }
                await _repository.DeleteAsync(value);
                return $"{id} id'li veri silindi";
            }, "HardDeleteAsync");
        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            return await ErrorHandlerHelper.ExecuteWithErrorHandling(async () =>
            {
                U value = await _repository.GetByIdAsync(id);
                if (value == null)
                {
                    throw new AppNotFoundException(typeof(U).Name, id);
                }
                if (value.Status == Domain.Enums.DataStatus.Deleted)
                {
                    throw new AppBusinessException("Veri zaten pasif");
                }
                value.Status = Domain.Enums.DataStatus.Deleted;
                value.DeletedDate = DateTime.Now;
                await _repository.SaveChangesAsync();
                return $"{id} id'li veri pasif hale getirildi";
            }, "SoftDeleteAsync");
        }

        public async Task UpdateAsync(T entity)
        {
            await ErrorHandlerHelper.ExecuteWithErrorHandling(async () =>
            {
                U originalValue = await _repository.GetByIdAsync(entity.Id);
                if (originalValue == null)
                {
                    throw new AppNotFoundException(typeof(U).Name, entity.Id);
                }
                U newValue = _mapper.Map<U>(entity);
                newValue.Status = Domain.Enums.DataStatus.Updated;
                newValue.UpdatedDate = DateTime.Now;
                await _repository.UpdateAsync(originalValue, newValue);
            }, "UpdateAsync");
        }
    }
}
