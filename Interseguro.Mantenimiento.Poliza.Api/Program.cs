using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Interseguro.Mantenimiento.Poliza.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args) 
            .UseStartup<Startup>();
         
    }
}
