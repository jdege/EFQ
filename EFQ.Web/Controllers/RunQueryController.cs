using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFQ.Web.DbContexts;
using EFQ.Web.Entities;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// #TODO: Remove Newtonsoft
using NJ = Newtonsoft.Json;
using SJ = System.Text.Json;

namespace JDege.EFQ.Web.Controllers
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
            var q = EFQBuilder.Any("InvoiceLines", EFQBuilder.Equal("Invoice.CustomerId", 1));
            var s = SJ.JsonSerializer.Serialize(q);

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id);
                if (storedQuery == null)
                {
                    return NotFound();
                }

                var efq = NJ.JsonConvert.DeserializeObject<EFQ>(storedQuery.StoredQueryJson);

                var predicate = efq.ConstructPredicate<Track>(null); ;

                var trackModels = await dbContext.Tracks
                    .Where(predicate)
                    .ProjectTo<TrackModel>(_configurationProvider)
                    .ToListAsync();

                var runQueryModel = new RunQueryModel
                {
                    TrackModels = trackModels,
                    Title = storedQuery.Name,
                    Query = storedQuery.Query,
                    Description = storedQuery.Description
                };

                return View(runQueryModel);
            }
        }
    }
}
