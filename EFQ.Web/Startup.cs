using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using JDege.EFQ.Web.DbContexts;

namespace JDege.EFQ.Web
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
            services.AddDbContextFactory<ChinookContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString("ChinookDbConnection"));
            }, ServiceLifetime.Scoped);

            services.AddAutoMapper(typeof(Startup));
            services.AddRazorPages();
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                // TODO: Customize Swagger pages.
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EFQ.Web", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFQ.Web v1"));

            app.UseStaticFiles();

            //this is a simple demo app, so we're not messing about with Https
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.MapEFQ("/efq");
        }
    }
}