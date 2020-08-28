using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace VueAdmin
{
    [DependsOn(
        typeof(AbpIdentityDomainSharedModule)
        )]
    public class VueAdminDomainSharedModule : AbpModule
    {

    }
}
