using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VueAdmin.EntityFrameworkCore
{
    public class VueAdminMigrationsDbContext : AbpDbContext<VueAdminMigrationsDbContext>
    {
        public VueAdminMigrationsDbContext(DbContextOptions<VueAdminMigrationsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureVueAdmin();
        }
    }
}