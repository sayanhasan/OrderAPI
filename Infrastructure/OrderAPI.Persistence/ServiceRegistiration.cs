using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderAPI.Application.Repositories.UnitOfWork;
using OrderAPI.Persistence.Contexts;
using OrderAPI.Persistence.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<OrderApiDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString),ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
