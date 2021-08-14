using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace JDege.EFQ
{
    /// <summary>
    /// Extension methods for IApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Maps javascript embedded resources into a web project's routing space
        /// </summary>
        /// <param name="app">this IApplicationBuilder</param>
        /// <param name="localPath">The route where the javascript files should be mapped</param>
        /// <returns></returns>
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