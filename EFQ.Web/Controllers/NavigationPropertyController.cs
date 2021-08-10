using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFQ.Web.DbContexts;
using EFQ.Web.Entities;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JDege.EFQ.Web.Controllers
{
    public class NavigationPropertyController : Controller
    {
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;

        public NavigationPropertyController(IDbContextFactory<ChinookContext> contextFactory, IConfigurationProvider configurationProvider)
        {
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            ViewBag.docs = @"
<p>EFQ queries can match against records that are associated with the base record through Entity Framework navigation properties.
";

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQueryArea = StoredQuery.StoredQueryArea.NavigationProperty.ToString();
                var storedQueryModels = await dbContext.StoredQueries
                    .Where(sq => sq.Area == storedQueryArea)
                    .ProjectTo<StoredQueryModel>(_configurationProvider)
                    .ToListAsync(cancellationToken);

                return View("StoredQueries", storedQueryModels);
            }
        }
    }
}
