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
        private readonly IMapper _mapper;

        public RunQueryController(IDbContextFactory<ChinookContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
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
        public async Task<IActionResult> GetInvoiceAsync([FromRoute] int id, [FromRoute] string rc, [FromQuery] string ctx)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id);
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
    }
}

