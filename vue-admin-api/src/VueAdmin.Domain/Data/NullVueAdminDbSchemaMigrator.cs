using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace VueAdmin.Data
{
    /* This is used if database provider does't define
     * IVueAdminDbSchemaMigrator implementation.
     */
    public class NullVueAdminDbSchemaMigrator : IVueAdminDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}