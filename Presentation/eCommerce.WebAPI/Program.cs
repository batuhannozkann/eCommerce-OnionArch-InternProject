using eCommerce.Application.Validators.Products;
using eCommerce.Infrastructure.Filters;
using eCommerce.Persistence;
using eCommerce.Persistence.Options;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;

namespace eCommerce.WebAPI
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>()).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductValidator>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}