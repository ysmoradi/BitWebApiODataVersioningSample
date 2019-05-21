using Bit.OwinCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace BitWebApiODataVersioningSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await BuildWebHost(args)
                .RunAsync();
        }

        public static IWebHost BuildWebHost(string[] args) =>
                    BitWebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>()
                        .Build();
    }
}
