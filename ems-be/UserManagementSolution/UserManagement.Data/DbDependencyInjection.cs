﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UserManagement.Common.Constants;
using UserManagement.Data.Data;

namespace UserManagement.Data
{
    public static class DbDependencyInjection
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<EmsDataContext>(options =>
                options.UseSqlServer(GetConnectionString(configuration)));
            return services;
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            var server = configuration[KeyVaultSecretConst.EmsDbServer];
            var database = configuration[KeyVaultSecretConst.EmsDbName];
            var user = configuration[KeyVaultSecretConst.EmsDbUser];
            var password = configuration[KeyVaultSecretConst.EmsDbPassword];

            return $"Server={server};Database={database};User Id={user};Password={password};";
        }
    }
}
