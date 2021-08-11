using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
    public class SqlStatementController : Controller
    {
        private const string PageTitle = "Sql Statements";
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<SqlStatementController> _logger;

        public SqlStatementController(IDbContextFactory<ChinookContext> contextFactory,
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
            ViewBag.docs = await this.GetContentsAsync(_webHostEnvironment, "documentation/SqlStatement_docs.html", cancellationToken);
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
            ViewBag.docs = await this.GetContentsAsync(_webHostEnvironment, "documentation/SqlStatement_docs.html", cancellationToken);
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
                var connectionString = dbContext.Database.GetConnectionString();

                // We need to do a multi-way join in order to pull together all the data we need.
                var query = new StringBuilder(@"
SELECT 
    t.[Name] AS [TrackName], 
    a.[Title] AS [AlbumTitle], 
    ar.[Name] AS [ArtistName], 
    t.[Composer] as [TrackComposer], 
    m.[Name] as [MediaType], 
    c.[FirstName] AS [CustomerFirstName], 
    c.[LastName] as [CustomerLastName] 
FROM Track t 
JOIN MediaType m
    ON m.MediaTypeId = t.MediaTypeId
JOIN Album a 
    ON a.AlbumId = t.AlbumId 
JOIN Artist ar 
    ON ar.ArtistId = a.ArtistId 
JOIN InvoiceLine il 
    ON il.TrackId = t.TrackId 
JOIN Invoice i 
    ON i.InvoiceId = il.InvoiceId 
JOIN Customer c 
    ON c.CustomerId = i.CustomerId ");

                var customerExistSubquery = @"
EXISTS ( 
    SELECT 0 
    FROM InvoiceLine il2 
    JOIN Invoice i2 
        ON il2.InvoiceId = i2.InvoiceId 
    WHERE il2.TrackId = t.TrackId 
        AND i2.CustomerId = @customerId 
) ";

                if (!String.IsNullOrWhiteSpace(artistId))
                {
                    query.Append("WHERE a.[ArtistId] = @artistId ");
                    if (!String.IsNullOrWhiteSpace(customerId))
                    {
                        query.Append("AND ");
                        query.Append(customerExistSubquery);
                    }
                }
                else
                {
                    query.Append("WHERE ");
                    query.Append(customerExistSubquery);
                }

                query.Append("ORDER BY t.[Name] ASC ");

                var trackModelList = new List<TrackModel>();

                using (var con = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand(query.ToString(), con);

                    if (!String.IsNullOrWhiteSpace(customerId))
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                    if (!String.IsNullOrWhiteSpace(artistId))
                        cmd.Parameters.AddWithValue("@artistId", artistId);

                    try
                    {
                        con.Open();
                        var rdr = await cmd.ExecuteReaderAsync(cancellationToken);

                        // Because there is a one-to-many relationship between Track and Invoice, our join
                        // returns multiple rows for each Track record.
                        while (await rdr.ReadAsync(cancellationToken))
                        {
                            var trackName = rdr.getValue<string>("TrackName");
                            var albumTitle = rdr.getValue<string>("AlbumTitle");
                            var artistName = rdr.getValue<string>("ArtistName");
                            var trackComposer = rdr.getValue<string>("TrackComposer");
                            var mediaType = rdr.getValue<string>("MediaType");
                            var customerFirstName = rdr.getValue<string>("CustomerFirstName");
                            var customerLastName = rdr.getValue<string>("CustomerLastName");

                            // If this is the first time we've seen this Track, we add a new model to the list
                            // And whether it is the first time or not, we need to add the customer data
                            // to the model's customer list.
                            var trackModel = trackModelList.SingleOrDefault(t => t.TrackName == trackName);

                            var addingNew = false;
                            if (trackModel == null)
                            {
                                trackModel = new TrackModel
                                {
                                    TrackName = trackName,
                                    ArtistName = artistName,
                                    AlbumTitle = albumTitle,
                                    MediaType = mediaType,
                                    TrackComposer = trackComposer
                                };

                                addingNew = true;
                            }

                            // 
                            trackModel.Customers.Add(new TrackModel.Customer
                            {
                                FirstName = customerFirstName,
                                LastName = customerLastName
                            });

                            if (addingNew)
                            {
                                trackModelList.Add(trackModel);
                            }
                        }
                        rdr.Close();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Exception retrieving TrackModel list");
                        throw;
                    }
                }
                return trackModelList;
            }
        }

        private async Task<IEnumerable<SelectListItem>> GetArtistSelectionListAsync(CancellationToken cancellationToken)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var connectionString = dbContext.Database.GetConnectionString();

                var query = "SELECT ArtistId, Name FROM Artist ORDER BY Name";

                var rows = new List<SelectListItem> { new SelectListItem { Value = null, Text = "" } };

                using (var con = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand(query, con);

                    try
                    {
                        con.Open();
                        var rdr = await cmd.ExecuteReaderAsync(cancellationToken);
                        while (await rdr.ReadAsync(cancellationToken))
                        {
                            var artistId = rdr.getValue<string>("ArtistId");
                            var name = rdr.getValue<string>("Name");
                            var selectListItem = new SelectListItem
                            {
                                Value = artistId,
                                Text = $"{name} [{artistId}]"
                            };

                            rows.Add(selectListItem);
                        }
                        rdr.Close();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Exception constructing artist selection list");
                        throw;
                    }
                }

                return rows;
            }
        }

        private async Task<IEnumerable<SelectListItem>> GetCustomerSelectionListAsync(CancellationToken cancellationToken)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var connectionString = dbContext.Database.GetConnectionString();

                var query = "SELECT CustomerId, FirstName, LastName FROM Customer ORDER BY LastName, FirstName";

                var rows = new List<SelectListItem> { new SelectListItem { Value = null, Text = "" } };

                using (var con = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand(query, con);

                    try
                    {
                        con.Open();
                        var rdr = await cmd.ExecuteReaderAsync(cancellationToken);
                        while (await rdr.ReadAsync(cancellationToken))
                        {
                            var customerId = rdr.getValue<string>("CustomerId").Trim();
                            var firstName = rdr.getValue<string>("FirstName").Trim();
                            var lastName = rdr.getValue<string>("LastName").Trim();

                            var selectListItem = new SelectListItem
                            {
                                Value = customerId,
                                Text = $"{firstName} {lastName} [{customerId}]"
                            };

                            rows.Add(selectListItem);
                        }
                        rdr.Close();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Exception constructing customer selection list");
                        throw;
                    }
                }

                return rows;
            }
        }
    }
}
