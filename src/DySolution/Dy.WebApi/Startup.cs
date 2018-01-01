using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Dy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Dy.Data.Domain;
using Microsoft.AspNetCore.Identity;

namespace Dy.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services">依赖注入服务</param>
        public void ConfigureServices(IServiceCollection services)
        {

            //Db配置
            services.AddDbContext<DyDbContext>(u =>
            {
                u.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    m => m.MaxBatchSize(5000)
                    .MigrationsHistoryTable("SysMigrationHistory")
                    .UseRelationalNulls(true)
                    .UseRowNumberForPaging(true)
                );
            });

            //Db上下文池配置
            services.AddDbContextPool<DyDbContext>(u =>
            {
                u.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    m => m.MaxBatchSize(5000)
                    .MigrationsHistoryTable("SysMigrationHistory")
                    .UseRelationalNulls(true)
                    .UseRowNumberForPaging(true)
                );
            });

            //认证配置
            services.AddIdentity<SysUser, SysRole>()
                .AddEntityFrameworkStores<DyDbContext>()
                .AddDefaultTokenProviders();

            //帮助文档配置
            services.AddSwaggerGen(config =>
            {
                Info info = new Info
                {
                    Title = "Api接口",
                    Version = "v1",
                    Description = ""
                };

                config.SwaggerDoc("v1", info);

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Dy.WebApi.xml");
                config.IncludeXmlComments(xmlPath);
            });

            //Mvc配置
            services.AddMvc(u =>
            {

            })
            .AddXmlSerializerFormatters();

            services.AddMvcCore().AddApiExplorer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Host = httpReq.Host.Value);

            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "DyApi-V1");
            });
        }
    }
}
