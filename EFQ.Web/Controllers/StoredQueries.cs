using System.Collections.Generic;
using JDege.EFQ.Web.Models;
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
            var storedQueries = new List<StoredQuery>{
                new StoredQuery{Id = 1, Name = "First", Description = "The first"},
                new StoredQuery{Id = 2, Name = "First", Description = "The second"},
                new StoredQuery{Id = 3, Name = "First", Description = "The third"},
            };
            return View(storedQueries);
        }
    }
}
