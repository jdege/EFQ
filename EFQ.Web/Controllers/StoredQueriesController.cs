using System.Linq;
using System.Threading.Tasks;
using EFQ.Web.DbContexts;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JDege.EFQ.Web.Controllers
{
    public class StoredQueriesController : Controller
    {
        private readonly IDbContextFactory<ChinookContext> _contextFactory;

        public StoredQueriesController(IDbContextFactory<ChinookContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuerModels = await dbContext.StoredQueries
                .Select(e => new StoredQueryModel
                {
                    Id = e.StoredQueryId,
                    Name = e.Name,
                    Description = e.Description
                })
                .ToListAsync();

                return View(storedQuerModels);
            }
        }
    }
}
