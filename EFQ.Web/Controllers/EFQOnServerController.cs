using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JDege.EFQ.Web.Controllers
{
    public class EFQOnServerController : Controller
    {
        private const string PageTitle = "EFQ On Server";
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<SqlStatementController> _logger;

        public EFQOnServerController(IConfigurationProvider configurationProvider,
            IWebHostEnvironment webHostEnvironment, ILogger<SqlStatementController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            ViewBag.docs = await GetContentsAsync(_webHostEnvironment, "documentation/EFQServer_docs.html", cancellationToken);
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
