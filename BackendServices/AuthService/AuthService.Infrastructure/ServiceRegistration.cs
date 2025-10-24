using AuthService.Application.Repositories;
using AuthService.Application.Services.Abstractions;
using AuthService.Infrastructure.Persistence.Repositories;
using AuthService.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using AuthService.Application.Services.Implementations;

namespace AuthService.Infrastructure
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register application services
            services.AddScoped<IUserAppService, UserAppService>();

            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // Register AutoMapper
            services.AddAutoMapper(cfg => cfg.AddProfile<AuthMapper>());

            // Register DbContext
            services.AddDbContext<AuthServiceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
        }
    }
}
