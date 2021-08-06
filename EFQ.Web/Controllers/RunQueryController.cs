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
                // TODO: rename RunTrackQueryModel
                // TODO: Use automapper to populate RunTrackQueryModel
                var runQueryModel = new RunTrackQueryModel
                {
                    StoredQueryId = storedQuery.StoredQueryId,
                    Title = storedQuery.Name,
                    Model = "TrackModel",
                    Query = storedQuery.Query,
                    Description = storedQuery.Description,
                    Parameters = null,
                    ReturnController = rc
                };

                return View("Index", runQueryModel);
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
                var runQueryModel = new RunTrackQueryModel
                {
                    StoredQueryId = storedQuery.StoredQueryId,
                    Title = storedQuery.Name,
                    Model = "InvoiceModel",
                    Query = storedQuery.Query,
                    Description = storedQuery.Description,
                    Parameters = null,
                    ReturnController = rc
                };

                return View("Index", runQueryModel);
            }
        }
    }
}

