using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GraphQLTest.Database
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppSQLContext>
    {
        public AppSQLContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppSQLContext>();
            var connectionString = configuration.GetConnectionString("GraphQLTestDb");
            builder.UseSqlServer(connectionString);

            return new AppSQLContext(builder.Options);
        }
    }
}
