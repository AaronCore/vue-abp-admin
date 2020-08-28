using System.Threading.Tasks;

namespace VueAdmin.Data
{
    public interface IVueAdminDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
