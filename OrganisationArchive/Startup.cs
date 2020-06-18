using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrganisationArchive.DAL;
using OrganisationArchive.DAL.Repository.Implementations;
using OrganisationArchive.DAL.Repository.Interfaces;

namespace OrganisationArchive
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            services.AddDbContext<OrganizationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("OrganizationDbConnection")));
            services.AddScoped<OrganizationDbContext, OrganizationDbContext>();
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<IUOW,UOW>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            MigrateDb(app, env);
        }
        private void MigrateDb(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                using (var scope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
                {
                    var dbContextObject = scope.ServiceProvider.GetService<OrganizationDbContext>();

                    /* comment this lines if you don't need db to be droped and create each time you run the app*/
                    if (env.IsDevelopment())
                    {
                        dbContextObject.Database.EnsureDeleted();
                    }
                    //**************************************

                    dbContextObject.Database.Migrate();

                    var dbInitializer = scope.ServiceProvider.GetService<IDatabaseInitializer>();
                    dbInitializer.Seed().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
