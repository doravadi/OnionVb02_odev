using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Contract.RepositoryInterfaces
{
    public interface IRepository<T> where T:class,IEntity
    {
        //Queries
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> exp);


        //Commands
        Task CreateAsync(T entity);
        Task UpdateAsync(T oldEntity,T newEntity);
        Task DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
