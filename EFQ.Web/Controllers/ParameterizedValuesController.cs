using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFQ.Web.DbContexts;
using EFQ.Web.Entities;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JDege.EFQ.Web.Controllers
{
    public class ParameterizedValuesController : Controller
    {
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;

        public ParameterizedValuesController(IDbContextFactory<ChinookContext> contextFactory, IConfigurationProvider configurationProvider)
        {
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            ViewBag.docs = @"
<p>Storing queries in the database serves little purpose if you can't set parameters when they're run.
</p>
<p>In this example, we're passing a dictionary of context values as a URLencoded query parameter.
</p>
<p>System.Text.Json won't deserialize JSON into object properties, so we need to include type information in the values
as we serialize them. We're doing this by the EFQ.Constant class instead. This will include type information when it serializes, and
will use that to reconstruct the correct type when deserializing.
</p>
<p>EFQ.js includes a EFQConstant object containing convenience functions to create ConstantValue types in the browser.
</p>
<p>E.g.:<br />
<code>var context = { ""trackid"": EFQConstant.int(2) };</code>
</p>
";

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQueryArea = StoredQuery.StoredQueryArea.ParameterizedValues.ToString();
                var storedQueryModels = await dbContext.StoredQueries
                    .Where(sq => sq.Area == storedQueryArea)
                    .ProjectTo<StoredQueryModel>(_configurationProvider)
                    .ToListAsync();

                return View("StoredQueries", storedQueryModels);
            }
        }
    }
}
