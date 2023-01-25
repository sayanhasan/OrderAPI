using OrderAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T:BaseEntity
    {
        Task<T> AddAsync(T entity);
        bool Remove(T entity);
        Task<bool> RemoveById(int id);
        T Update(T entity);
    }
}
