using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace JDege.EFQ.Web.Controllers
{
    public static class ControllerExtension
    {
        // TODO: Consider whether loading docs from external files is really necessary
        public static async Task<string> GetContentsAsync(this Controller controllers,
            IWebHostEnvironment _webHostEnvironment, string path, CancellationToken cancellationToken)
        {
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            var contents = await System.IO.File.ReadAllTextAsync(filepath, cancellationToken);
            return contents;
        }
    }
}
