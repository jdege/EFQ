using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFQ.Web.DbContexts;
using EFQ.Web.Entities;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JDege.EFQ.Web.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly ILogger<TrackController> _logger;
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;

        public TrackController(ILogger<TrackController> logger, IConfigurationProvider configurationProvider,
            IDbContextFactory<ChinookContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackModel>>> GetAsync(string artistId, string customerId)
        {
            var andQueriesList = new List<EFQ>();

            andQueriesList.Add(EFQBuilder.IsTrue());

            if (!string.IsNullOrEmpty(artistId))
            {
                var a = int.Parse(artistId);

                andQueriesList.Add(EFQBuilder.Equal("Album.ArtistId", a));
            }

            if (!string.IsNullOrEmpty(customerId))
            {
                var c = int.Parse(customerId);

                andQueriesList.Add(EFQBuilder.Any("InvoiceLines", EFQBuilder.Equal("Invoice.CustomerId", c)));
            }

            var query = EFQBuilder.And(andQueriesList);

            var predicate = query.ConstructPredicate<Track>();

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var trackModelList = await dbContext.Tracks.Where(predicate)
                    .OrderBy(t => t.Name)
                    .ProjectTo<TrackModel>(_configurationProvider)
                    .ToListAsync();

                return trackModelList;
            }
        }

        [HttpPost]
        [Route("Query")]
        public async Task<ActionResult<IEnumerable<TrackModel>>> QueryAsync(EFQ query)
        {
            try
            {
                var predicate = query.ConstructPredicate<Track>();

                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    var trackModelList = await dbContext.Tracks.Where(predicate)
                        .OrderBy(t => t.Name)
                        .ProjectTo<TrackModel>(_configurationProvider)
                        .ToListAsync();

                    return trackModelList;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception encountered");
                throw;
            }
        }


        [HttpPost]
        [Route("StoredQuery/{id}")]
        public async Task<ActionResult<IEnumerable<TrackModel>>> StoredQueryAsync([FromRoute] int id, [FromBody] Dictionary<string, EFQ.Constant> context)
        {
            try
            {
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(s => s.StoredQueryId == id);

                    if (storedQuery == null)
                        return NotFound();

                    var query = JsonSerializer.Deserialize<EFQ>(storedQuery.StoredQueryJson);

                    var predicate = query.ConstructPredicate<Track>(context);

                    var trackModelList = await dbContext.Tracks.Where(predicate)
                        .OrderBy(t => t.Name)
                        .ProjectTo<TrackModel>(_configurationProvider)
                        .ToListAsync();

                    return trackModelList;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception encountered");
                throw;
            }
        }
    }
}
