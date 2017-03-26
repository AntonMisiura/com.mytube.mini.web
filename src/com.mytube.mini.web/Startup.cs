using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using com.mytube.mini.impl.EF;
using com.mytube.mini.impl.EF.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using React.AspNet;

namespace com.mytube.mini.web
{
    public class Startup
    {
        private IConfigurationRoot _config;
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            services.AddSingleton(_config);

            services.AddDbContext<TubeContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<IRepository<Video>, Repository<Video>>();
            services.AddTransient<IRepository<Rating>, Repository<Rating>>();


            services.AddMvc()
                .AddJsonOptions(config =>
                {
                    config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }


        public void Configure(IApplicationBuilder app)
        {
            app.UseReact(config => { });

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );

                config.MapRoute(
                    name: "log",
                    template: "User/Login/{id?}",
                    defaults: new { controller = "User", action = "Login" }
                    );
            });
        }
    }
}
