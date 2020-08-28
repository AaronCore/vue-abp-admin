using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VueAdmin.Data;
using Volo.Abp.DependencyInjection;

namespace VueAdmin.EntityFrameworkCore
{
    public class EntityFrameworkCoreVueAdminDbSchemaMigrator
        : IVueAdminDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreVueAdminDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the VueAdminMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<VueAdminMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}