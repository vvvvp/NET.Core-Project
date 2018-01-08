using Basics.Application;
using Basics.Application.DepartmentApp;
using Basics.Application.MenuApp;
using Basics.Application.RoleApp;
using Basics.Application.UserApp;
using Basics.Domain.IRepositories;
using Basics.EntityFrameworkCore;
using Basics.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using MySql.Data;
using System.IO;

namespace NET.Core_Project
{
    /// <summary>
    /// 应用程序相关启动项配置，包含ConfigureServices和Configure两个方法
    /// ConfigureServices:负责服务的配置
    /// Configure:负责http请求管道的配置
    /// </summary>
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            //初始化映射关系
            BasicsMapper.Initialize();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //获取数据库连接字符串
            var sqlConnectionString = Configuration.GetConnectionString("Default");
            #region Mysql连接
            //借鉴https://www.cnblogs.com/wangjieguang/p/EFCore-MySQL.html
            //添加数据上下文
            services.AddDbContext<BasicsDBContext>(options => options.UseMySQL(sqlConnectionString));
            #endregion

            #region SqlServer连接
            //services.AddDbContext<BasicsDBContext>(options => options.UseSqlServer(sqlConnectionString));
            #endregion

            #region 依赖注入
            //注意：Asp.Net Core提供的依赖注入拥有三种生命周期模式，由短到长依次为：
            //Transient ServiceProvider总是创建一个新的服务实例。
            //Scoped ServiceProvider创建的服务实例由自己保存，（同一次请求）所以同一个ServiceProvider对象提供的服务实例均是同一个对象。也是AddDbContext默认
            //Singleton 始终是同一个实例对象
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentAppService, DepartmentAppService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleAppService, RoleAppService>();
            #endregion

            //MVC
            services.AddMvc();
            //Session服务
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 添加MVC服务及Http请求管道处理
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                //开发环境异常处理
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //生产环境异常处理
                app.UseExceptionHandler("/Shared/Error");
            }
            //使用静态文件
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
            });

            //Session
            app.UseSession();
            //使用Mvc，设置默认路由为系统登录
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });

            //SeedData.Initialize(app.ApplicationServices); //初始化数据(添加点数据)
        }
    }
}
