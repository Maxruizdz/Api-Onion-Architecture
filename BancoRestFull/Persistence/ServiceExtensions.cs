using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceExtensions
    {

        public static void AddPersistenceInfraestructure(this IServiceCollection service, IConfiguration configuration) {

            service.AddDbContext<ApplicationDbContexts>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContexts).Assembly.FullName)));


            #region Repositories
            service.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositotyAsync<>));
            #endregion
            #region Caching
            service.AddStackExchangeRedisCache(options =>
            {

                options.Configuration = configuration.GetValue<string>("Caching:RedisConnection");


            });

            #endregion

        }



    }
}
