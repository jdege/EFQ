using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


using JDege.EFQ.Web.DbContexts;
using JDege.EFQ.Web.ExtensionClasses;
using JDege.EFQ.Web.Models;

namespace JDege.EFQ.Web.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;

        public ArtistController(ILogger<CustomerController> logger, IConfigurationProvider configurationProvider,
            IDbContextFactory<ChinookContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
        }

        [HttpGet]
        [Route("GetDropdown")]
        public async Task<IEnumerable<DropdownModel>> GetDropdownAsync(bool includeQueries, CancellationToken cancellationToken)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var dropdownModels = await dbContext.Artists
                    .OrderBy(a => a.Name)
                    .ProjectTo<DropdownModel>(_configurationProvider)
                    .ToListAsync(cancellationToken);

                if (includeQueries)
                {
                    foreach (var model in dropdownModels)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        var efq = EFQBuilder.Equal("Album.ArtistId", Int32.Parse(model.value));
                        model.query = efq;
                    }
                }

                return dropdownModels;
            }
        }
    }
}