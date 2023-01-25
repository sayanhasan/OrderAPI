using Microsoft.EntityFrameworkCore;
using OrderAPI.Application.Repositories;
using OrderAPI.Domain.Common;
using OrderAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly OrderApiDbContext _context;

        public WriteRepository(OrderApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            var model =  await Table.AddAsync(entity);
            return model.Entity;
        }

        public bool Remove(T entity)
        {
            var model = Table.Remove(entity);
            return model.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveById(int id)
        {
            var model = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return Remove(model);
        }

        public T Update(T entity)
        {
            var model = Table.Update(entity);
            return model.Entity;
        }
    }
}
