using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace VueAdmin
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(VueAdminApplicationModule)
        )]
    public class VueAdminHttpApiModule : AbpModule
    {

    }
}
