using System.Reflection;
using EFQ;
using EFQ.Web.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

namespace JDege.EFQ.Web
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EFQ.Web", Version = "v1" });
            });


            // var efqManifestEmbeddedProvider =
            //     new ManifestEmbeddedFileProvider(typeof(EFQ).Assembly);
            // // var compositeProvider =
            // //     new CompositeFileProvider(efqManifestEmbeddedProvider);

            // services.AddSingleton<IFileProvider>(efqManifestEmbeddedProvider);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFQ.Web v1"));

            app.UseStaticFiles();

            //this is a simple demo app
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });

            app.MapEFQ("/efq");
            // app.Map("/efq", builder =>
            // {
            //     var provider = new ManifestEmbeddedFileProvider(
            //         assembly: Assembly.GetAssembly(typeof(EFQ)), "JavaScript");
            //     builder.UseStaticFiles(new StaticFileOptions
            //     {
            //         FileProvider = provider
            //     });
            //     // builder.Run(async context =>
            //     // {
            //     //     await context.Response.SendFileAsync(provider.GetFileInfo("EFQ.js"));
            //     // });
            // });

            // app.UseFileServer(new FileServerOptions
            // {
            //     RequestPath = "/efq",
            //     FileProvider = new ManifestEmbeddedFileProvider(
            //             assembly: Assembly.GetAssembly(typeof(EFQ)))
            // });
        }
    }
}
