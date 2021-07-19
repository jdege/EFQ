using System;
using System.Linq;
using System.Text;
using EFQ.Web.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JDege.EFQ.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private static Random random = new();
        private readonly IDbContextFactory<ChinookContext> _contextFactory;

        public EmployeeController(IDbContextFactory<ChinookContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            StringBuilder sb = new();
            sb.AppendLine("These are the artists:");

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var artists = dbContext.Artists.ToList();

                foreach (var artist in artists)
                {
                    sb.AppendLine($"{artist.Name}");
                }
            }

            ViewData["contents"] = sb.ToString();

            return View();
        }
    }
}
