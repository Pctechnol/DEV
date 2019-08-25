using InsightConsulting.Domain;
using InsightConsulting.Domain.Interfaces;
using InsightConsulting.EF;
using InsightConsulting.EF.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsightConsulting.Web
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
            services.AddSingleton(Configuration);

            services.AddDbContext<InsightConsultingDbContext>(
               context =>
               {
                   context.UseSqlServer(Configuration["InsightConsultingDB:DefaultConnection"],
                       options =>
                       {
                           options.EnableRetryOnFailure();
                       });
               });

            services.AddScoped(typeof(InsightConsultingDomain));
            services.AddScoped(typeof(DbContext), typeof(InsightConsultingDbContext));
            services.AddScoped(typeof(IDomainQueryProvider), typeof(InsightConsultingDbContext));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Users/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Users}/{action=Index}/{id?}");
            });
        }
    }
}
