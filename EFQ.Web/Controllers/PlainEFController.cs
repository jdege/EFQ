using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFQ.Web.DbContexts;
using JDege.EFQ.Web.Extensions;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JDege.EFQ.Web.Controllers
{
    public class PlainEFController : Controller
    {
        private const string PageTitle = "Plain Entity Framework";
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<SqlStatementController> _logger;

        public PlainEFController(IDbContextFactory<ChinookContext> contextFactory,
        IConfigurationProvider configurationProvider, IWebHostEnvironment webHostEnvironment, ILogger<SqlStatementController> logger)
        {
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            ViewBag.docs = await GetContentsAsync(_webHostEnvironment, "documentation/ADO_docs.html");
            ViewBag.explanationActive = "active";
            ViewBag.criteriaActive = null;
            ViewBag.resultsActive = null;

            var trackFormModel = new TrackFormModel
            {
                Title = PageTitle,
                Artists = await GetArtistSelectionListAsync(),
                Customers = await GetCustomerSelectionListAsync()
            };

            return View("TrackMVC", trackFormModel);
        }

        [HttpPost]
        public async Task<ActionResult> IndexAsync(TrackFormModel trackFormModel)
        {
            ViewBag.docs = await GetContentsAsync(_webHostEnvironment, "documentation/ADO_docs.html");
            ViewBag.explanationActive = null;
            ViewBag.criteriaActive = null;
            ViewBag.resultsActive = "active";

            trackFormModel.Title = PageTitle;
            trackFormModel.Artists = await GetArtistSelectionListAsync();
            trackFormModel.Customers = await GetCustomerSelectionListAsync();

            trackFormModel.TrackModels = await GetTrackModels(trackFormModel.ArtistId, trackFormModel.CustomerId);

            return View("TrackMVC", trackFormModel);
        }

        private async Task<IList<TrackModel>> GetTrackModels(string artistId, string customerId)
        {
            if (String.IsNullOrWhiteSpace(artistId) && String.IsNullOrWhiteSpace(customerId))
                throw new ArgumentException("Must supply at least one of ArtistId or CustomerId");

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var query = dbContext.Tracks.AsQueryable();

                if (!string.IsNullOrEmpty(artistId))
                {
                    var a = int.Parse(artistId);

                    query = query.Where(t => t.Album.ArtistId == a);
                }

                if (!string.IsNullOrEmpty(customerId))
                {
                    var c = int.Parse(customerId);

                    query = query.Where(t => t.InvoiceLines.Any(il => il.Invoice.CustomerId == c));
                }

                var trackModelList = await query
                    .OrderBy(t => t.Name)
                    .ProjectTo<TrackModel>(_configurationProvider)
                    .ToListAsync();

                return trackModelList;
            }
        }

        private async Task<IEnumerable<SelectListItem>> GetArtistSelectionListAsync()
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var rowList = new List<SelectListItem> { new SelectListItem { Value = null, Text = "" } };

                var rows = await dbContext.Artists
                    .OrderBy(a => a.Name)
                    .Select(a =>
                        new SelectListItem
                        {
                            Value = a.ArtistId.ToString(),
                            Text = $"{a.Name} [{a.ArtistId}]"
                        }
                    )
                    .ToListAsync()
                    ;

                rowList.AddRange(rows);

                return rowList;
            }
        }

        private async Task<IEnumerable<SelectListItem>> GetCustomerSelectionListAsync()
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var rowList = new List<SelectListItem> { new SelectListItem { Value = null, Text = "" } };

                var rows = await dbContext.Customers
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.FirstName)
                    .Select(c =>
                        new SelectListItem
                        {
                            Value = c.CustomerId.ToString(),
                            Text = $"{c.FirstName} {c.LastName} [{c.CustomerId}]"
                        })
                    .ToListAsync()
                    ;

                rowList.AddRange(rows);

                return rowList;
            }
        }

        public async Task<string> GetContentsAsync(IWebHostEnvironment _webHostEnvironment, string path)
        {
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            var contents = await System.IO.File.ReadAllTextAsync(filepath);
            return contents;
        }
    }
}
