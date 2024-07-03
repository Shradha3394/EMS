using AutoMapper;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using UserManagement.Api.Middleware;
using UserManagement.Common.Constants;
using UserManagement.Data;
using UserManagement.Services.Abstract;
using UserManagement.Services.Concrete;
using UserManagement.Services.Mappings;
using UserManagement.Services.Mappings.UserManagement.Common.Mappings;

namespace UserManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Azure Key Vault to configuration
            var keyVaultEndpoint = builder.Configuration[KeyVaultSecretConst.Endpoint];
            if (!string.IsNullOrEmpty(keyVaultEndpoint))
            {
                builder.Configuration.AddAzureKeyVault(
                    new Uri(keyVaultEndpoint),
                    new DefaultAzureCredential());
            }

            // Add services to the container.

            builder.Services.AddDbContext(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IUserService, UserService>();

            // Suppress the automatic model state validation globally
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var key = Encoding.ASCII.GetBytes(builder.Configuration[KeyVaultSecretConst.JwtSecretKey] ?? string.Empty);
            builder.Services.AddAuthentication().AddJwtBearer(option =>
                {
                    option.SaveToken = true;
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                }
            );

            var app = builder.Build();

            // Configure AutoMapper with dependency injection
            var serviceProvider = app.Services;
            var mapper = serviceProvider.GetRequiredService<IMapper>();
            MappingExtensions.ConfigureMapper(mapper);

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.Run();
        }
    }
}
