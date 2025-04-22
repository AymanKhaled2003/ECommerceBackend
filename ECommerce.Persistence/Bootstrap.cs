using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.Services;
using ECommerce.Persistence.Repositories;
using ECommerce.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence
{
    public static class Bootstrap
    {
        public static IServiceCollection AddPersistenceStrapping(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenExtractor, TokenExtractor>();

            return services;
        }
    }

}
