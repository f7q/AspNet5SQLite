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

namespace AspNet5SQLite
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json");

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Production:SqliteConnectionString"];

            services.AddDbContext<DataEventRecordContext>(options =>
                options.UseSqlite(connection)
            );
            
            services.AddMvc();
            //services.AddScoped<IBLCService, BLCService>();
            //services.AddScoped<IDataEventRecordRepository, DataEventRecordRepository>();

            var builder = new ContainerBuilder();

#if NET451
            var myAssembly = Assembly.GetExecutingAssembly();
#else
            //var myAssembly = GetExecutingAssembly();
            // TODO: Remove private reflection when we get this: https://github.com/dotnet/corefx/issues/4146
            var getEntryAssemblyMethod =
                typeof(Assembly).GetMethod("GetEntryAssembly", BindingFlags.Static | BindingFlags.NonPublic) ??
                typeof(Assembly).GetMethod("GetEntryAssembly", BindingFlags.Static | BindingFlags.Public);
            var myAssembly = getEntryAssemblyMethod.Invoke(obj: null, parameters: Array.Empty<object>()) as Assembly;
#endif
            builder.RegisterAssemblyTypes(myAssembly)
               .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces();
            //builder.RegisterType<MyType>().As<IMyType>();
            builder.Populate(services);
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

         public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();

            app.UseMvc();
        }

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
        /*
        public static Assembly GetExecutingAssembly()
        {
            Assembly asm = null;
            Type t = typeof(Startup);
            TypeInfo ti = t.GetTypeInfo();
            asm = ti.Assembly;

            return asm;
        }
        */
    }
}
