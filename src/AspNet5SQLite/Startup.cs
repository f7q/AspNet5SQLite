using AspNet5SQLite.Model;
using AspNet5SQLite.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;

using AspNet5SQLite.Services;
using Autofac;
using System;
using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;
using Autofac.Extensions.DependencyInjection;
using Swashbuckle.SwaggerGen.Generator;

using NLog.Web;
using NLog.Extensions.Logging;

namespace AspNet5SQLite
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public IConfigurationRoot Configuration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json");

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Production:SqliteConnectionString"];
            var pathToDoc = Configuration["Swagger:Path"];

            services.AddDbContext<DataEventRecordContext>(options =>
                options.UseSqlite(connection)
            );
            
            services.AddMvc();

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Geo Search API",
                    Description = "A simple api to search using geo location in Elasticsearch",
                    TermsOfService = "None"
                });
                options.IncludeXmlComments(pathToDoc);
                options.DescribeAllEnumsAsStrings();
            });

            var builder = new ContainerBuilder();

#if NET451
            var myAssembly = Assembly.GetExecutingAssembly();
#else
            var myAssembly = Assembly.GetEntryAssembly();
#endif
            builder.RegisterAssemblyTypes(myAssembly)
               .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces();
            builder.Populate(services);
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //add NLog to ASP.NET Core
            loggerFactory.AddNLog();

            //add NLog.Web
            app.AddNLogWeb();
            //needed for non-NETSTANDARD platforms: configure nlog.config in your project root
            env.ConfigureNLog("nlog.config");
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwaggerGen();
            app.UseSwaggerUi();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
