using AutoMapper;
using eCommerce.Application.Mapping;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.UnitOfWork;
using eCommerce.Domain.Identity;
using eCommerce.Infrastructure.Token;
using eCommerce.Persistence.Contexts;
using eCommerce.Persistence.Options;
using eCommerce.Persistence.Repositories;
using eCommerce.Persistence.Repositories.Generic;
using eCommerce.Persistence.Services;
using Microsoft.AspNetCore.Identity;
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
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<eCommerceDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, eCommerce.Persistence.UnitOfWork.UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseRepositoryNoTracking<>), typeof(BaseRepositoryNoTracking<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAddressService,AddressService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IShippingRepository, ShippingRepository>();
            services.AddScoped<IShippingService,ShippingService>();
            services.AddScoped<IShippingCompanyRepository, ShippingCompanyRepository>();
            services.AddScoped<IShippingCompanyService, ShippingCompanyService>();
            services.AddScoped<IAdminService,AdminService>();
            services.AddAutoMapper(typeof(MapProfile));
            
            return services;
        }
    }
}
