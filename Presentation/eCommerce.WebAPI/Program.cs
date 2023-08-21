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
using Microsoft.OpenApi.Models;
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
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    var tokenOptions = builder.Configuration.GetSection("Accesstoken").Get<CustomTokenOption>();
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {

                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,


                        ValidAudience = tokenOptions.Audience[0],
                        ValidIssuer = tokenOptions.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                    };
                });
            builder.Services.Configure<IdentityOptions>(options => {
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API",
                    Version = "v2",
                    Description = "Your Api Description"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });

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
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            
            app.Run();
        }
    }
}