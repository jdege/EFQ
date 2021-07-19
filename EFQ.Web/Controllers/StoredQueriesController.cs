using System.Collections.Generic;
using EFQ.Web.DbContexts;
using EFQ.Web.Entities;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JDege.EFQ.Web.Controllers
{
    public class StoredQueriesController : Controller
    {
        private ChinookContext dbContext;

        public StoredQueriesController(ChinookContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var storedQueries = new List<StoredQueryModel>
            {
                new StoredQueryModel{Id = 1, Name = "First", Description = "The first"},
                new StoredQueryModel{Id = 2, Name = "First", Description = "The second"},
                new StoredQueryModel{Id = 3, Name = "First", Description = "The third"},
            };
            return View(storedQueries);
        }
    }
}
