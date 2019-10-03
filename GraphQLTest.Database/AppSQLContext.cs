using GraphQLTest.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.Database
{
    public class AppSQLContext : DbContext
    {
        public AppSQLContext(DbContextOptions<AppSQLContext> options)
               : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
