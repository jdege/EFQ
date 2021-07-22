using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFQ.Web.DbContexts;
using EFQ.Web.Entities;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JDege.EFQ.Web.ApiControllers
{
    public class RunQueryController : Controller
    {
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;

        public RunQueryController(IDbContextFactory<ChinookContext> contextFactory, IConfigurationProvider configurationProvider)
        {
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
        }

        [HttpGet]
        [Route("[Controller]/{id}")]
        public async Task<IActionResult> IndexAsync(int id)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id);
                if (storedQuery == null)
                {
                    return NotFound();
                }

                var efq = JsonConvert.DeserializeObject<EFQ>(storedQuery.StoredQueryJson);
                var predicate = efq.ConstructSinglePredicate<Album>(null);

                var albumModels = await dbContext.Albums
                    .Where(predicate)
                    .ProjectTo<AlbumModel>(_configurationProvider)
                    .ToListAsync();

                return View(albumModels);
            }
        }
    }
}
