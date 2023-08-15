using eCommerce.Application.Validators.Products;
using eCommerce.Infrastructure.Filters;
using eCommerce.Infrastructure.Token;
using eCommerce.Persistence;
using eCommerce.Persistence.Options;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eCommerce.WebAPI
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>()).AddNewtonsoftJson(opt=>opt.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {

                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,


                        ValidAudience = builder.Configuration["Token:Audience"],
                        ValidIssuer = builder.Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SignKey"]))
                    };
                });
            builder.Services.Configure<IdentityOptions>(options => {
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });
            builder.Services.AddSwaggerGen();
            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings"));
            builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("AccessToken"));

            var app = builder.Build();
            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            
            app.UseHttpsRedirection();
            app.UseMiddleware<CustomMiddleware>();
            app.UseAuthorization();
            app.MapControllers();
            
            app.Run();
        }
    }
}