using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFQ.Web.DbContexts;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JDege.EFQ.Web.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IEnumerable<ArtistDropdownModel>> GetDropdownAsync()
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var artistDropdownModels = await dbContext.Artists
                    .OrderBy(a => a.Name)
                    .ProjectTo<ArtistDropdownModel>(_configurationProvider)
                    .ToListAsync();

                return artistDropdownModels;
            }
        }

    }
}
