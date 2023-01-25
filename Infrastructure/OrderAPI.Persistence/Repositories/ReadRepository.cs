using Microsoft.EntityFrameworkCore;
using OrderAPI.Application.Repositories;
using OrderAPI.Domain.Common;
using OrderAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly OrderApiDbContext _context;

        public ReadRepository(OrderApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var table = Table.AsQueryable();
            if (!tracking) return await table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            else return await table.FirstOrDefaultAsync(x => x.Id == id);
        }
        //=> await Table.FindAsync(id);

        public IQueryable<T> GetList(bool tracking = true)
        {
            var table = Table.AsQueryable();
            if (!tracking) table = table.AsNoTracking();
            return table;
        }

        public IQueryable<T> GetListByFilter(Expression<Func<T, bool>> filter = null, int? skip = null, int? take = null, string[] includes = null, bool orderByAsc = true, bool tracking = true)
        {
            var table = Table.AsQueryable();
            if (filter != null) table = Table.Where(filter);
            if (skip.HasValue) table = table.Skip(skip.GetValueOrDefault());
            if (take.HasValue) table = table.Take(take.GetValueOrDefault());
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    table = table.Include(include);
                }
            }
            if (orderByAsc) table = table.OrderBy(x => x.Id);
            if (!tracking) table = table.AsNoTracking();
            return table;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter) => await Table.AsNoTracking().FirstOrDefaultAsync(filter);

    }
}
