using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VueAdmin.EntityFrameworkCore
{
    public class VueAdminMigrationsDbContextFactory : IDesignTimeDbContextFactory<VueAdminMigrationsDbContext>
    {
        public VueAdminMigrationsDbContext CreateDbContext(string[] args)
        {
            VueAdminEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<VueAdminMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new VueAdminMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
