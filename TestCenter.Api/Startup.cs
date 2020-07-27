using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.IO;
using TestCenter.Admin.WebApi.Controllers;
using TestCenter.Business.AutoJob;
using TestCenter.Util;
using TestCenter.Util.Model;

namespace TestCenter.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            GlobalContext.LogWhenStart(env);
            GlobalContext.HostingEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "TestCenter Api", Version = "v1" });
            });

            services.AddOptions();
            services.AddCors();
            services.AddControllers(options =>
            {
                options.ModelMetadataDetailsProviders.Add(new ModelBindingMetadataProvider());
            }).AddNewtonsoftJson(options =>
            {
                // 返回数据首字母不小写，CamelCasePropertyNamesContractResolver是小写
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddMemoryCache();
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(GlobalContext.HostingEnvironment.ContentRootPath + Path.DirectorySeparatorChar + "DataProtection"));

            GlobalContext.SystemConfig = Configuration.GetSection("SystemConfig").Get<SystemConfig>();
            GlobalContext.Services = services;
            GlobalContext.Configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                GlobalContext.SystemConfig.Debug = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            string resource = Path.Combine(env.ContentRootPath, "Resource");
            FileHelper.CreateDirectory(resource);

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = GlobalContext.SetCacheControl
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/Resource",
                FileProvider = new PhysicalFileProvider(resource),
                OnPrepareResponse = GlobalContext.SetCacheControl
            });

            app.UseMiddleware(typeof(GlobalExceptionMiddleware));

            app.UseCors(builder =>
            {
                builder.WithOrigins(GlobalContext.SystemConfig.AllowCorsSite.Split(',')).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-doc/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-doc";
                c.SwaggerEndpoint("v1/swagger.json", "TestCenter Api v1");
            });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=ApiHome}/{action=Index}/{id?}");
            });
            GlobalContext.ServiceProvider = app.ApplicationServices;
            if (!GlobalContext.SystemConfig.Debug)
            {
                new JobCenter().Start(); // 定时任务
            }
        }
    }
}
