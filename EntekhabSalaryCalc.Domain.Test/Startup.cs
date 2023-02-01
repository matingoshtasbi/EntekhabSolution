using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EntekhabSalaryCalc.Application.Core.Abstractions;
using EntekhabSalaryCalc.Application.Core.Exceptions.ErrorHandling;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using EntekhabSalaryCalc.Infrastructure.Persistence.DbContexts;
using EntekhabSalaryCalc.Infrastructure.ReadModules.DbContexts;
using EntekhabSalaryCalc.Infrastructure.Persistence.UnitofWork;
using EntekhabSalaryCalc.Infrastructure.ErrorHandling;
using EntekhabSalaryCalc.Infrastructure.AutoMapper;
using EntekhabSalaryCalc.Application.DependencyInjectionExtensions;
using EntekhabSalaryCalc.Infrastructure.Persistence.Sqlite.DbContexts;
using EntekhabSalaryCalc.Infrastructure.Persistence.SqlServer.DbContexts;
using Microsoft.Data.Sqlite;

namespace EntekhabSalaryCalc.Domain.Test
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var keepAliveConnection = new SqliteConnection(Configuration.GetConnectionString("InMemoryConnection"));
            keepAliveConnection.Open();

            services.AddDbContext<CommandDbContext, SqliteCommandDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlite(keepAliveConnection));

            services.AddDbContext<QueryDbContext>(options =>
                options.UseSqlite(keepAliveConnection), ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, MainUnitOfWork>();

            services.AddTransient<IExceptionHandler, ExceptionHandler>();
            services.AddAutoMapper(typeof(EmployeeManagementProfile));
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddLocalization();

            services.AddRequestLocalization(x =>
            {
                x.DefaultRequestCulture = new RequestCulture("en");
                x.ApplyCurrentCultureToResponseHeaders = true;
                x.SupportedCultures = new List<CultureInfo> { new("fa"), new("en") };
                x.SupportedUICultures = new List<CultureInfo> { new("fa"), new("en") };
            });

            services.AddEmployeeManagementModules();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CommandDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            app.UseMiddleware<ApplicationExceptionMiddleware>();
            app.UseStaticFiles();

        }
    }
}
