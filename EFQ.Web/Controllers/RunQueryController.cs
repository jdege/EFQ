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
using System.Text.Json;
using System.Net;

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
        [Route("[Controller]/Track/{id}")]
        public async Task<IActionResult> GetTrackAsync([FromRoute] int id, [FromQuery] string rc, [FromQuery] string ctx)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id);
                if (storedQuery == null)
                {
                    return NotFound();
                }

                var efq = JsonSerializer.Deserialize<EFQ>(storedQuery.StoredQueryJson);

                // TODO: Need to deserialize Context!!!
                Dictionary<string, EFQ.Constant> context = null;
                if (ctx != null)
                {
                    var c = WebUtility.UrlDecode(ctx);
                    context = JsonSerializer.Deserialize<Dictionary<string, EFQ.Constant>>(c);
                }

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
        [Route("[Controller]/Invoice/{id}")]
        public async Task<IActionResult> GetInvoiceAsync([FromRoute] int id, [FromRoute] string rc, [FromQuery] string ctx)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id);
                if (storedQuery == null)
                {
                    return NotFound();
                }

                var efq = JsonSerializer.Deserialize<EFQ>(storedQuery.StoredQueryJson);
                var context = storedQuery.Context == null ? null : JsonSerializer.Deserialize<Dictionary<string, EFQ.Constant>>(storedQuery.Context);

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
