using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

// TODO: Do we need License.cshtml.cs?
namespace JDege.EFQ.Web.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}