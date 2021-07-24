using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace EFQ
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder MapEFQ(this IApplicationBuilder app, string localPath)
        {
            app.Map(localPath, builder =>
            {
                var provider = new ManifestEmbeddedFileProvider(
                    assembly: Assembly.GetExecutingAssembly(), "JavaScript");
                builder.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = provider
                });
            });

            return app;
        }
    }
}