using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrderAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrderApiDbContext>
    {
        public OrderApiDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder optBuilder = new();
            optBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(optBuilder.Options);
        }
    }
}
