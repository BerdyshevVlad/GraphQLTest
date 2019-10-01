using GraphQLTest.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.Database
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
               : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
