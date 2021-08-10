using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
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
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<TrackController> _logger;
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;

        public InvoiceController(ILogger<TrackController> logger, IConfigurationProvider configurationProvider,
            IDbContextFactory<ChinookContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
        }

        [HttpPost]
        [Route("StoredQuery/{id}")]
        public async Task<ActionResult<IEnumerable<InvoiceModel>>> StoredQueryAsync(int id,
            [FromBody] Dictionary<string, EFQ.Constant> context, CancellationToken cancellationToken)
        {
            try
            {
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(s => s.StoredQueryId == id, cancellationToken);

                    if (storedQuery == null)
                        return NotFound();

                    var query = JsonSerializer.Deserialize<EFQ>(storedQuery.StoredQueryJson);

                    var predicate = query.ConstructPredicate<Invoice>(context);

                    var invoiceModelList = await dbContext.Invoices.Where(predicate)
                        .OrderBy(t => t.InvoiceDate)
                        .ProjectTo<InvoiceModel>(_configurationProvider)
                        .ToListAsync(cancellationToken);

                    return invoiceModelList;
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
