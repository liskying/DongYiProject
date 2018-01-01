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
using Dy.Data.Initialize;
using Dy.Service;

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
                    Configuration.GetConnectionString("DefaultConnection")
                , m => m
                //.MaxBatchSize(5000)
                .MigrationsHistoryTable("SysMigration")
                .UseRowNumberForPaging(true)
                );
            });

            //Db上下文池配置
            //services.AddDbContextPool<DyDbContext>(u =>
            //{
            //    u.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")
            //    //, m => m
            //    //.MaxBatchSize(5000)
            //    //.MigrationsHistoryTable("SysMigration")
            //    //.UseRowNumberForPaging(true)
            //    );
            //});

            //认证配置
            services.AddIdentity<SysUser, SysRole>()
                .AddEntityFrameworkStores<DyDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserValidator<SysUser>, UserValidator<SysUser>>();
            services.AddScoped<PasswordHasher<SysUser>, PasswordHasher<SysUser>>();

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

                var xmlPath2 = Path.Combine(basePath, "Dy.Dto.xml");
                config.IncludeXmlComments(xmlPath2);

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
        /// <param name="db"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DyDbContext db)
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

            var settings = Configuration.GetSection("AppSettings");
            if (Configuration.GetConnectionString("AutoUpdateDb") == "true")
            {
                //数据库更新
                DbInitializer.InitializeAsync(db);
            }
            if (Configuration.GetConnectionString("AutoInitData") == "true")
            {  //初始数据库
                InitializeDatabase(app);
            }
        }

        /// <summary>
        /// 初始Db数据
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var provider = serviceScope.ServiceProvider;
                //上下文
                var db = provider.GetRequiredService<DyDbContext>();
               
                if (db.Database.EnsureCreated())
                {
                    //Db已创建,初始数据不在执行
                    return;
                }

                var userValidator = provider.GetRequiredService<IUserValidator<SysUser>>();
                var passwordHasher = provider.GetRequiredService<IPasswordHasher<SysUser>>();

                //用户设置
                var userAdmin = CreateUserForAdmin(db, userValidator, passwordHasher);
                if (!db.SysUser.Any(u => u.UserName == userAdmin.UserName))
                {
                    db.SysUser.Add(userAdmin);
                }
                else
                {
                    userAdmin = db.SysUser.FirstOrDefault(u => u.UserName == userAdmin.UserName);
                }

                //角色设置
                var roleAdmin = CreateRoleForAdmin(db);
                if (!db.SysRole.Any(u => u.Name == roleAdmin.Name))
                {
                    db.SysRole.Add(roleAdmin);
                }
                else
                {
                    roleAdmin = db.SysRole.FirstOrDefault(u => u.Name == roleAdmin.Name);
                }

                //用户角色
                if (!db.SysUserRole.Any(u => u.UserId == userAdmin.Id && u.RoleId == roleAdmin.Id))
                {
                    db.SysUserRole.Add(new SysUserRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        RoleId = roleAdmin.Id,
                        CreateTime = DateTime.Now,
                        DeleteState = DeleteState.Normal,
                        IsMajor = true,
                        UpdateTime = DateTime.Now,
                        UserId = userAdmin.Id,
                    });
                };

                //部门
                var deptAdmin = CreateDeptForAdmin(db);
                if (!db.SysDept.Any(u => u.DeptCode == deptAdmin.DeptCode))
                {
                    db.SysDept.Add(deptAdmin);
                }
                else
                {
                    deptAdmin = db.SysDept.FirstOrDefault(u => u.DeptCode == deptAdmin.DeptCode);
                }

                //用户部门
                if (!db.SysUserDept.Any(u => u.UserId == userAdmin.Id && u.DeptId == deptAdmin.Id))
                {
                    db.SysUserDept.Add(new SysUserDept
                    {
                        Id = Guid.NewGuid().ToString(),
                        DeptId = deptAdmin.Id,
                        CreateTime = DateTime.Now,
                        DeleteState = DeleteState.Normal,
                        IsMajor = true,
                        UpdateTime = DateTime.Now,
                        UserId = userAdmin.Id,
                        JobState = true,
                        StartDate = DateTime.Now,
                    });
                };

                db.SaveChanges();
            }


        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        private SysUser CreateUserForAdmin(DyDbContext db, IUserValidator<SysUser> userValidator, IPasswordHasher<SysUser> passwordHasher)
        {

            IUserStore<SysUser> userStore = new SysUserStore(db);

            var userAdmin = new SysUser
            {
                Id = Guid.NewGuid().ToString(),
                AccessFailedCount = 0,
                CreateTime = DateTime.Now,
                Creator = "root",
                DeleteState = DeleteState.Normal,
                Email = "liwenxue1012@163.com",
                EmpName = "admin",
                SortId = 1,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false,
                PhoneNumber = "13761669737",
                UpdateTime = DateTime.Now,
                IsSupper = true,
                EmailConfirmed = false,
                EmpNo = "0001",
                EmpSex = "先生",
                UserName = "admin",
                EmpBirth = "1986-10-12",
                EmpPinyin = "lwx",
                NormalizedUserName = "admin",

            };
            passwordHasher.HashPassword(userAdmin, "123456");
            return userAdmin;
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private SysRole CreateRoleForAdmin(DyDbContext db)
        {
            var role = new SysRole()
            {
                Id = Guid.NewGuid().ToString(),
                CreateTime = DateTime.Now,
                Creator = "root",
                DeleteState = DeleteState.Normal,
                IsSystem = true,
                Name = "超级管理员",
                SortId = 1,
                UpdateTime = DateTime.Now,
                NormalizedName = "超级管理员"
            };
            return role;
        }

        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private SysDept CreateDeptForAdmin(DyDbContext db)
        {
            var role = new SysDept()
            {
                Id = Guid.NewGuid().ToString(),
                CreateTime = DateTime.Now,
                Creator = "root",
                DeleteState = DeleteState.Normal,
                SortId = 1,
                UpdateTime = DateTime.Now,
                Address = "上海市XXX路100弄1号",
                DeptCode = "ROOTDEPT",
                DeptLevel = 0,
                DeptName = "顶级部门",
                DeptType = "集团",
                Tel = "23490234"
            };
            return role;
        }

    }
}
