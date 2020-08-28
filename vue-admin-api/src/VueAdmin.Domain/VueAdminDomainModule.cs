using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace VueAdmin
{
    [DependsOn(
        typeof(VueAdminDomainSharedModule),
        typeof(AbpIdentityDomainModule)
        )]
    public class VueAdminDomainModule : AbpModule
    {

    }
}
