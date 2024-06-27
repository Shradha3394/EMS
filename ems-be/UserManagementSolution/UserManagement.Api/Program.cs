using AutoMapper;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Common.Constants;
using UserManagement.Data;
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
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Suppress the automatic model state validation globally
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var app = builder.Build();

            // Configure AutoMapper with dependency injection
            var serviceProvider = app.Services;
            var mapper = serviceProvider.GetRequiredService<IMapper>();
            MappingExtensions.ConfigureMapper(mapper);

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}
