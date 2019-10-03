using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLTest.DataAcess.Repositories;
using GraphQLTest.DataAcess.Repositories.Interfaces;
using GraphQLTest.Database;
using GraphQLTest.GQLTypes.Landlord;
using GraphQLTest.GQLTypes.Payment;
using GraphQLTest.GQLTypes.Property;
using GraphQLTest.Mutations;
using GraphQLTest.Queries;
using GraphQLTest.Schema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GraphQLTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        IMongoDatabase database; // база данных

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string connectionString = Configuration.GetValue<string>("MongoConnection:ConnectionString");
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString); 
             // получаем доступ к самой базе данных
             database = client.GetDatabase(connection.DatabaseName);


            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<ILandlordRepository>(x=>new LandlordRepository(database));

            services.AddDbContext<GraphQLTest.Database.AppSQLContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:GraphQLTestDb"]));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<PropertyQuery>();
            services.AddSingleton<PropertyMutation>();
            services.AddSingleton<LandlordMutation>();
            services.AddSingleton<PropertyType>();
            services.AddSingleton<PropertyInputType>();
            services.AddSingleton<LandlordInputType>();
            services.AddSingleton<PaymentType>();
            services.AddSingleton<LandlordType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new AppSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GraphQLTest.Database.AppSQLContext db)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<GraphQLTest.Database.AppSQLContext>();
                context.Database.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
            db.EnsureSeedData(database);
        }
    }
}
