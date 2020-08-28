using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace VueAdmin.EntityFrameworkCore
{
    [DependsOn(
        typeof(VueAdminEntityFrameworkCoreModule)
        )]
    public class VueAdminEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<VueAdminMigrationsDbContext>();
        }
    }
}
