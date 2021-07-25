using System;
using System.Collections.Generic;
using System.Linq;
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
            if (String.IsNullOrWhiteSpace(artistId) && String.IsNullOrWhiteSpace(customerId))
                throw new ArgumentException("Must supply at least one of ArtistId or CustomerId");

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
    }
}
