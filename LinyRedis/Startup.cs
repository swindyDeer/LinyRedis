using Autofac.Core;
using CSRedis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO;

namespace LinyRedis
{
    public class Startup
    {
        /// <summary>
        /// 配置
        /// </summary>
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AppModule>();
            services.AddLogging(logging=> {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LinyRedis API", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "LinyRedis.xml");
                c.IncludeXmlComments(filePath);
            });

            //缓存设置
            var cacheConnectionString = Configuration.GetConnectionString("RedisConnection");
            RedisHelper.Initialization(new CSRedisClient(cacheConnectionString));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
