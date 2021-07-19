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
        // #TODO: Inject DbContextFactory
        private ChinookContext dbContext;

        public StoredQueriesController(ChinookContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
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
