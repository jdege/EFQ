using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using JDege.EFQ.Web.DbContexts;
using JDege.EFQ.Web.Models;

namespace JDege.EFQ.Web.Controllers
{
    public class EntityFrameworkController : Controller
    {
        private const string PageTitle = "Entity Framework";
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<SqlStatementController> _logger;

        public EntityFrameworkController(IDbContextFactory<ChinookContext> contextFactory,
            IMapper mapper, IWebHostEnvironment webHostEnvironment, ILogger<SqlStatementController> logger)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            ViewBag.docs = await GetContentsAsync(_webHostEnvironment, "documentation/EntityFramework_docs.html", cancellationToken);
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
            ViewBag.docs = await GetContentsAsync(_webHostEnvironment, "documentation/EntityFramework_docs.html", cancellationToken);
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

                // We need to .Include() all the navigation properties that we need to build TrackModels
                // (Which means we're still pulling mutiple records)
                var trackList = await query
                    .Include(t => t.MediaType)
                    .Include(t => t.Album).ThenInclude(a => a.Artist)
                    .Include(t => t.InvoiceLines).ThenInclude(il => il.Invoice).ThenInclude(i => i.Customer)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken);

                // We're using AutoMapper to map our Track entities to our TrackModel models.
                var trackModelList =
                    _mapper.Map<IList<TrackModel>>(trackList);

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