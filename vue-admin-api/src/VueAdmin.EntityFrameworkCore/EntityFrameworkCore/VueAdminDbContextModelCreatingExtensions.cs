using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace VueAdmin.EntityFrameworkCore
{
    public static class VueAdminDbContextModelCreatingExtensions
    {
        public static void ConfigureVueAdmin(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(VueAdminConsts.DbTablePrefix + "YourEntities", VueAdminConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}