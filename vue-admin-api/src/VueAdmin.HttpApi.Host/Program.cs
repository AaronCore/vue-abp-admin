using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using VueAdmin.Common.Extensions;
using VueAdmin.Configurations;

namespace VueAdmin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseLog4Net()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseIISIntegration()
                        .ConfigureKestrel(options =>
                        {
                            options.AddServerHeader = false;
                        })
                        //.UseUrls($"http://*:{AppSettings.ListenPort}")
                        .UseStartup<Startup>();
                })
                .UseAutofac();
    }
}
