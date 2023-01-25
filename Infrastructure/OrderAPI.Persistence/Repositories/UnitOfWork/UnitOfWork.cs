using OrderAPI.Application.Repositories;
using OrderAPI.Application.Repositories.UnitOfWork;
using OrderAPI.Domain;
using OrderAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Persistence.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderApiDbContext _context;

        public UnitOfWork(OrderApiDbContext context)
        {
            _context = context;
        }

        public IReadRepository<Product> ProductReadRepo => new ReadRepository<Product>(_context);

        public IWriteRepository<Product> ProductWriteRepo => new WriteRepository<Product>(_context);

        public IReadRepository<Order> OrderReadRepo => new ReadRepository<Order>(_context);

        public IWriteRepository<Order> OrderWriteRepo => new WriteRepository<Order>(_context);

        public IReadRepository<Company> CompanyReadRepo => new ReadRepository<Company>(_context);

        public IWriteRepository<Company> CompanyWriteRepo => new WriteRepository<Company>(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
