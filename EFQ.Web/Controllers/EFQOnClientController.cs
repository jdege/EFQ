using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JDege.EFQ.Web.Controllers
{
    public class EFQOnClientController : Controller
    {
        private const string PageTitle = "EFQ On Client";
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ADOController> _logger;

        public EFQOnClientController(IConfigurationProvider configurationProvider,
            IWebHostEnvironment webHostEnvironment, ILogger<ADOController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;

            var assembly = typeof(EFQBuilder).Assembly;
            var resources = assembly.GetManifestResourceNames();
            using (var resourceStream = assembly.GetManifestResourceStream("EFQ.JavaScript.EFQ.js"))
            {
                var rdr = new StreamReader(resourceStream);
                var contents = rdr.ReadToEnd();
            }
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            ViewBag.docs = await GetContentsAsync(_webHostEnvironment, "documentation/efqc_docs.html");
            ViewBag.explanationActive = "active";
            ViewBag.criteriaActive = null;
            ViewBag.resultsActive = null;
            return View();
        }

        // #TODO: hunt out every reference to the name EFQuery

        // #TODO: Rename "Dynamic Queries" and "Stored Queries"

        // #TODO: Add explanatory html section to stored queries table
        // #TODO: Add json data context section to stored queries table
        // #TODO: Make EFQ support data context objects

        // #TODO: Create partial view(?) for dynamic queries subobject.
        public async Task<string> GetContentsAsync(IWebHostEnvironment _webHostEnvironment, string path)
        {
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            var contents = await System.IO.File.ReadAllTextAsync(filepath);
            return contents;
        }
    }
}
