using CatalogService.Application.DTOs;
using CatalogService.Application.Mappers;
using CatalogService.Application.Repositories;
using CatalogService.Application.Services.Abstractions;
using CatalogService.Application.Services.Implementations;
using CatalogService.Infrastructure.Persistence;
using CatalogService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services,IConfiguration configuration)
        {
            //Register DBContext
            services.AddDbContext<CatalogServiceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            //Register application services
            services.AddScoped<IProductAppService, ProductAppService>();
            //Register repositories
            services.AddScoped<IProductRepository,ProductRepository>();
            //Register AutoMapper
            services.AddAutoMapper(cfg => cfg.AddProfile<ProductMapper>());
        }
    }
}
