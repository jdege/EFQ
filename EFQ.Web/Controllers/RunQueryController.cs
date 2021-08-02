using System;
using System.Collections.Generic;
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
        [Route("[Controller]/Track")]
        public async Task<IActionResult> GetTrackAsync(int id, string rc)
        {
            var q = EFQBuilder.LessThanOrEqual("InvoiceDate", DateTime.Parse("2009-01-31"));
            var s = SJ.JsonSerializer.Serialize(q);

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id);
                if (storedQuery == null)
                {
                    return NotFound();
                }

                var efq = NJ.JsonConvert.DeserializeObject<EFQ>(storedQuery.StoredQueryJson);
                var context = storedQuery.Context == null ? null : NJ.JsonConvert.DeserializeObject<Dictionary<string, object>>(storedQuery.Context);

                var predicate = efq.ConstructPredicate<Track>(context); ;

                var trackModels = await dbContext.Tracks
                    .Where(predicate)
                    .ProjectTo<TrackModel>(_configurationProvider)
                    .ToListAsync();

                var runQueryModel = new RunTrackQueryModel
                {
                    TrackModels = trackModels,
                    Title = storedQuery.Name,
                    Query = storedQuery.Query,
                    Context = storedQuery.Context,
                    Description = storedQuery.Description,
                    ReturnController = rc
                };

                return View("Tracks", runQueryModel);
            }
        }

        [HttpGet]
        [Route("[Controller]/Invoice")]
        public async Task<IActionResult> GetInvoiceAsync(int id, string rc)
        {
            var q = EFQBuilder.Equal("BillingCountry", "Germany");
            var s = SJ.JsonSerializer.Serialize(q);

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id);
                if (storedQuery == null)
                {
                    return NotFound();
                }

                var efq = NJ.JsonConvert.DeserializeObject<EFQ>(storedQuery.StoredQueryJson);
                var context = storedQuery.Context == null ? null : NJ.JsonConvert.DeserializeObject<Dictionary<string, object>>(storedQuery.Context);

                var predicate = efq.ConstructPredicate<Invoice>(context); ;

                var invoiceModels = await dbContext.Invoices
                    .Where(predicate)
                    .ProjectTo<InvoiceModel>(_configurationProvider)
                    .ToListAsync();

                var runQueryModel = new RunInvoiceQueryModel
                {
                    InvoiceModels = invoiceModels,
                    Title = storedQuery.Name,
                    Query = storedQuery.Query,
                    Context = storedQuery.Context,
                    Description = storedQuery.Description,
                    ReturnController = rc
                };

                return View("Invoices", runQueryModel);
            }
        }
    }
}
