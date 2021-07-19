using System;
using System.Linq;
using System.Text;
using EFQ.Web.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace JDege.EFQ.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private static Random random = new();
        private ChinookContext dbContext;

        public EmployeeController(ChinookContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            StringBuilder sb = new();
            sb.AppendLine("These are the artists:");

            var artists = dbContext.Artists.ToList();

            foreach (var artist in artists)
            {
                sb.AppendLine($"{artist.Name}");
            }

            ViewData["contents"] = sb.ToString();

            return View();
        }
    }
}
