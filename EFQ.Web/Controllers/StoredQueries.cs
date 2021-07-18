
using System;
using System.Linq;
using System.Text;
using JDege.EFQ.Web.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JDege.EFQ.Web.Controllers
{
    public class StoredQueriesController : Controller
    {
        private ChinookDbContext dbContext;

        public StoredQueriesController(ChinookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
