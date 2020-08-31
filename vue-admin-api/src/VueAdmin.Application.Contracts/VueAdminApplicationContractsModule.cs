using Volo.Abp.Modularity;

namespace VueAdmin.Application.Contracts
{
    [DependsOn(
        typeof(VueAdminDomainModule)
    )]
    public class VueAdminApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
