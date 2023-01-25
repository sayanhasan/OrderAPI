using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IReadRepository<Product> ProductReadRepo { get; }
        IWriteRepository<Product> ProductWriteRepo { get; }
        IReadRepository<Order> OrderReadRepo { get; }
        IWriteRepository<Order> OrderWriteRepo { get; }
        IReadRepository<Company> CompanyReadRepo { get; }
        IWriteRepository<Company> CompanyWriteRepo { get; }
        Task<int> CommitAsync();
    }
}
