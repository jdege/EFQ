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

using System.Text.Json;
using System.Net;
using System.Threading;

namespace JDege.EFQ.Web.Controllers
{
    public class RunQueryController : Controller
    {
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        private readonly IMapper _mapper;

        public RunQueryController(IDbContextFactory<ChinookContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[Controller]/Track/{id}")]
        public async Task<IActionResult> GetTrackAsync([FromRoute] int id, [FromQuery] string rc, CancellationToken cancellationToken)
        {
            // TODO: Remove debugging comments
            // var q = EFQBuilder.Or(
            //     EFQBuilder.Contains("Composer", "{{Context:match}}"),
            //     EFQBuilder.Contains("Album.Title", "{{Context:match}}"),
            //     EFQBuilder.Contains("Album.Artist.Name", "{{Context:match}}")
            // );

            // var s = JsonSerializer.Serialize(q);
            // var d = JsonSerializer.Deserialize<EFQ>(s);

            // var ctx = new Dictionary<string, EFQ.Constant>
            // {
            //     { "match", new EFQ.Constant("brazil")}
            // };

            // TODO: Parameterized values Return to list not working
            // TODO: Parameterized artistid not working

            // TODO: do a parameterized "contains" against all fields.

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                // var predicate = q.ConstructPredicate<Track>(ctx);

                // var found = dbContext.Tracks.Where(predicate).ProjectTo<TrackModel>(_mapper.ConfigurationProvider).ToList();

                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id, cancellationToken);
                if (storedQuery == null)
                {
                    return NotFound();
                }

                var runQueryModel = _mapper.Map<RunQueryModel>(storedQuery, opt =>
                {
                    opt.Items["Model"] = "TrackModel";
                    opt.Items["ReturnController"] = rc;
                    opt.Items["Parameters"] = storedQuery.ParametersJson == null ? null : JsonSerializer.Deserialize<IList<RunQueryModel.Parameter>>(storedQuery.ParametersJson);
                });

                return View("Index", runQueryModel);
            }
        }

        [HttpGet]
        [Route("[Controller]/Invoice/{id}")]
        public async Task<IActionResult> GetInvoiceAsync([FromRoute] int id, [FromQuery] string rc, CancellationToken cancellationToken)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id, cancellationToken);
                if (storedQuery == null)
                {
                    return NotFound();
                }

                var runQueryModel = _mapper.Map<RunQueryModel>(storedQuery, opt =>
                {
                    opt.Items["Model"] = "InvoiceModel";
                    opt.Items["ReturnController"] = rc;
                    opt.Items["Parameters"] = storedQuery.ParametersJson == null ? null : JsonSerializer.Deserialize<IList<RunQueryModel.Parameter>>(storedQuery.ParametersJson);
                });

                return View("Index", runQueryModel);
            }
        }
    }
}

