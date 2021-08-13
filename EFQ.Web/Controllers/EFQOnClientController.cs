using System.IO;
using System.Threading;
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
        private readonly ILogger<SqlStatementController> _logger;

        public EFQOnClientController(IConfigurationProvider configurationProvider,
            IWebHostEnvironment webHostEnvironment, ILogger<SqlStatementController> logger)
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
        public async Task<IActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            ViewBag.docs = await GetContentsAsync(_webHostEnvironment, "documentation/EFQClient_docs.html", cancellationToken);
            ViewBag.explanationActive = "active";
            ViewBag.criteriaActive = null;
            ViewBag.resultsActive = null;
            return View();
        }

        public async Task<string> GetContentsAsync(IWebHostEnvironment _webHostEnvironment, string path, CancellationToken cancellationToken)
        {
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            var contents = await System.IO.File.ReadAllTextAsync(filepath, cancellationToken);
            return contents;
        }
    }
}


// TODO: Test in Windows

