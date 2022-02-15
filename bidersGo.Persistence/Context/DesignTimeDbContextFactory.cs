using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace bidersGo.Persistence.Context
{
    public abstract class DesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);
        public TContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TContext> builder = new DbContextOptionsBuilder<TContext>();
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../bidersGo"))
                .AddJsonFile("appsettings.json")
                .Build();
            builder.UseSqlServer(configuration.GetConnectionString("SQLServer"));

            //builder.UseSqlServer(ConnectionStrings.SQLServer);

            return CreateNewInstance(builder.Options);
        }
    }
}
