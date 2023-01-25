using OrderAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetList(bool tracking = true);
        IQueryable<T> GetListByFilter(Expression<Func<T, bool>> filter = null, int? skip = null, int? take = null, string[] includes = null, bool orderBy = true, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id,bool tracking = true);
    }
}
