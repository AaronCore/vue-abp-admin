using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace VueAdmin
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule)
        )]
    public class VueAdminApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
