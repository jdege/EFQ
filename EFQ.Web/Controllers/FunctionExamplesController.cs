using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFQ.Web.DbContexts;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JDege.EFQ.Web.Controllers
{
    public class FunctionExamplesController : Controller
    {
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;

        public FunctionExamplesController(IDbContextFactory<ChinookContext> contextFactory, IConfigurationProvider configurationProvider)
        {
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQueryModels = await dbContext.StoredQueries
                    .ProjectTo<StoredQueryModel>(_configurationProvider)
                    .ToListAsync();

                return View(storedQueryModels);
            }
        }
    }
}
