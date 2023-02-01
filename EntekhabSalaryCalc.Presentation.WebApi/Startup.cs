using EntekhabSalaryCalc.Application.Core.Abstractions;
using EntekhabSalaryCalc.Application.Core.Exceptions.ErrorHandling;
using EntekhabSalaryCalc.Application.DependencyInjectionExtensions;
using EntekhabSalaryCalc.Infrastructure.Persistence.UnitofWork;
using EntekhabSalaryCalc.Infrastructure.AutoMapper;
using EntekhabSalaryCalc.Infrastructure.ErrorHandling;
using EntekhabSalaryCalc.Infrastructure.Persistence.DbContexts;
using EntekhabSalaryCalc.Infrastructure.Persistence.Sqlite.DbContexts;
using EntekhabSalaryCalc.Infrastructure.Persistence.SqlServer.DbContexts;
using EntekhabSalaryCalc.Infrastructure.ReadModules.DbContexts;
using EntekhabSalaryCalc.Presentation.WebApi;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EntekhabSalaryCalc.Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<CommandDbContext, SqlServerCommandDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("MainConnection")));

            services.AddDbContext<QueryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MainConnection"))
                , ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, MainUnitOfWork>();

            services.AddTransient<IExceptionHandler, ExceptionHandler>();
            services.AddAutoMapper(typeof(EmployeeManagementProfile));
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddLocalization();

            services.AddRequestLocalization(x =>
            {
                x.DefaultRequestCulture = new RequestCulture("en" , "en");
                x.ApplyCurrentCultureToResponseHeaders = true;
                x.SupportedCultures = new List<CultureInfo> { new("fa"), new("en") };
                x.SupportedUICultures = new List<CultureInfo> { new("fa"), new("en") };
            });

            services.AddHttpContextAccessor();

            services.AddEmployeeManagementModules();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(config => config.OperationFilter<MyHeaderFilter>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();

                //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                //{
                //    var context = serviceScope.ServiceProvider.GetRequiredService<CommandDbContext>();
                //    context.Database.Migrate();
                //}
            }

            app.UseMiddleware<ApplicationExceptionMiddleware>();
            app.UseRequestLocalization();
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();

        }
    }
}