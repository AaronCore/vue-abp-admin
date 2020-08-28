using System;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace VueAdmin.Application.Caching
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(VueAdminDomainModule)
    )]
    public class VueAdminApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
