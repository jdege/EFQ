using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFQ.Web.DbContexts;
using EFQ.Web.Entities;
using JDege.EFQ.Web.Extensions;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeteMontgomery.PredicateBuilder;

// #TODO: DO a general cleanup - removing unused "usings", etc.
namespace JDege.EFQ.Web.Controllers
{
    public class PredicateBuilderController : Controller
    {
        private const string PageTitle = "Predicate Builder";
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<SqlStatementController> _logger;

        public PredicateBuilderController(IDbContextFactory<ChinookContext> contextFactory,
        IConfigurationProvider configurationProvider, IWebHostEnvironment webHostEnvironment, ILogger<SqlStatementController> logger)
        {
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            ViewBag.docs = await GetContentsAsync(_webHostEnvironment, "documentation/PredicateBuilder_docs.html", cancellationToken);
            ViewBag.explanationActive = "active";
            ViewBag.criteriaActive = null;
            ViewBag.resultsActive = null;

            var trackFormModel = new TrackFormModel
            {
                Title = PageTitle,
                Artists = await GetArtistSelectionListAsync(cancellationToken),
                Customers = await GetCustomerSelectionListAsync(cancellationToken)
            };

            return View("TrackMVC", trackFormModel);
        }

        [HttpPost]
        public async Task<ActionResult> IndexAsync(TrackFormModel trackFormModel, CancellationToken cancellationToken)
        {
            ViewBag.docs = await GetContentsAsync(_webHostEnvironment, "documentation/PredicateBuilder_docs.html", cancellationToken);
            ViewBag.explanationActive = null;
            ViewBag.criteriaActive = null;
            ViewBag.resultsActive = "active";

            trackFormModel.Title = PageTitle;
            trackFormModel.Artists = await GetArtistSelectionListAsync(cancellationToken);
            trackFormModel.Customers = await GetCustomerSelectionListAsync(cancellationToken);

            trackFormModel.TrackModels = await GetTrackModels(trackFormModel.ArtistId, trackFormModel.CustomerId, cancellationToken);

            return View("TrackMVC", trackFormModel);
        }

        private async Task<IList<TrackModel>> GetTrackModels(string artistId, string customerId, CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.Create<Track>(t => true);

            if (!string.IsNullOrEmpty(artistId))
            {
                var a = int.Parse(artistId);

                predicate = predicate.And(PredicateBuilder.Create<Track>(t => t.Album.ArtistId == a));
            }

            if (!string.IsNullOrEmpty(customerId))
            {
                var c = int.Parse(customerId);

                predicate = predicate.And(PredicateBuilder.Create<Track>(t => t.InvoiceLines.Any(il => il.Invoice.CustomerId == c)));
            }

            // Because we're using AutoMapper's IQueryable.ProjectTo() extension method, EF is filtering the results
            // on the server, returning only the data that is needed to populate the models.
            // (This significantly reduces the amount of data we put on the wire.)
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var trackModelList = await dbContext.Tracks.Where(predicate)
                    .OrderBy(t => t.Name)
                    .ProjectTo<TrackModel>(_configurationProvider)
                    .ToListAsync(cancellationToken);

                return trackModelList;
            }
        }

        private async Task<IEnumerable<SelectListItem>> GetArtistSelectionListAsync(CancellationToken cancellationToken)
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
                    .ToListAsync(cancellationToken)
                    ;

                rowList.AddRange(rows);

                return rowList;
            }
        }

        private async Task<IEnumerable<SelectListItem>> GetCustomerSelectionListAsync(CancellationToken cancellationToken)
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
                    .ToListAsync(cancellationToken)
                    ;

                rowList.AddRange(rows);

                return rowList;
            }
        }

        public async Task<string> GetContentsAsync(IWebHostEnvironment _webHostEnvironment, string path, CancellationToken cancellationToken)
        {
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            var contents = await System.IO.File.ReadAllTextAsync(filepath, cancellationToken);
            return contents;
        }
    }
}
