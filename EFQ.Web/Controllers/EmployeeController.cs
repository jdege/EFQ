
using System;
using System.Linq;
using System.Text;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace JDege.EFQ.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private static Random random = new();
        private ChinookDbContext dbContext;

        public EmployeeController(ChinookDbContext dbContext)
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