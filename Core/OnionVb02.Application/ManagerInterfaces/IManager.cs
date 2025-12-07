using OnionVb02.Application.DTOClasses;
using OnionVb02.Application.DTOInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.ManagerInterfaces
{
    public interface IManager<T,U> where T: class,IDto where U:class,IEntity
    {
        //BL for Queries
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetUpdateds();


        //BL for Commands

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<string> SoftDeleteAsync(int id);
        Task<string> HardDeleteAsync(int id);
    }
}
