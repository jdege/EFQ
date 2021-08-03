using System;
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
    [Route("api/[controller]")]
    public class MediaTypeController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;

        public MediaTypeController(ILogger<CustomerController> logger, IConfigurationProvider configurationProvider,
            IDbContextFactory<ChinookContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
        }

        [HttpGet]
        [Route("GetDropdown")]
        public async Task<IEnumerable<DropdownModel>> GetDropdownAsync(bool includeQueries)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var dropdownModels = await dbContext.MediaTypes
                    .OrderBy(c => c.Name)
                    .ProjectTo<DropdownModel>(_configurationProvider)
                    .ToListAsync();

                if (includeQueries)
                {
                    foreach (var model in dropdownModels)
                    {
                        var efq = EFQBuilder.Equal("MediaTypeId", Int32.Parse(model.value));
                        model.query = efq;
                    }

                    dropdownModels.AddRange(new[] {
                        new DropdownModel{
                            value = "",
                            text = "Audio",
                            query = EFQBuilder.Contains("MediaType.Name", "Audio")
                        },
                        new DropdownModel{
                            value = "",
                            text = "Video",
                            query = EFQBuilder.Contains("MediaType.Name", "Video")
                        },
                        new DropdownModel{
                            value = "",
                            text = "Protected or Purchased",
                            query = EFQBuilder.Or(
                                EFQBuilder.Contains("MediaType.Name", "Protected"),
                                EFQBuilder.Contains("MediaType.Name", "Purchased"))
                        }
                    });
                }

                return dropdownModels;
            }
        }
    }
}
