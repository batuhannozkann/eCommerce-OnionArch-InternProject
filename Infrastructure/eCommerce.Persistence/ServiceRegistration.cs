using AutoMapper;
using eCommerce.Application.Mapping;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Persistence.Contexts;
using eCommerce.Persistence.Options;
using eCommerce.Persistence.Repositories;
using eCommerce.Persistence.Repositories.Generic;
using eCommerce.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence
{
    public static class ServiceRegistration
    {
        
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<eCommerceDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IServiceWithDto<,>), typeof(ServiceWithDto<,>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(MapProfile));
            return services;
        }
    }
}
