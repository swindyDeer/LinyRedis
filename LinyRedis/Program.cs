using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace LinyRedis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private  static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder=Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseAutofac();

            return builder;
        }

    }
}

