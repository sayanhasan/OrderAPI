using Microsoft.EntityFrameworkCore;
using OrderAPI.Domain.Common;

namespace OrderAPI.Application.Repositories
{
    public interface IRepository<T>where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
