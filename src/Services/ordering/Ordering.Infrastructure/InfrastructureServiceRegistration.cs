using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contracts.Infrastracture;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Models;
using Ordering.Infrastructure.Mail;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<OrderingContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("Connection"));
            });
            services.AddTransient(typeof(IAsyncRepo<>) , typeof(RepositoryBase<>));
            services.AddTransient<IOrderRepo, OrderRepo>();

            services.Configure<EmailSettings>(s => config.GetSection("EmailSettings"));
            services.AddScoped<IEmailRepo, EmailService>();
            return services;

        }
    }
}
