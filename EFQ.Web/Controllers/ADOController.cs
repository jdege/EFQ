using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    public class ADOController : Controller
    {
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        // Injecting AutoMapper configuration
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ADOController> _logger;

        public ADOController(IDbContextFactory<ChinookContext> contextFactory,
        IConfigurationProvider configurationProvider, IWebHostEnvironment webHostEnvironment, ILogger<ADOController> logger)
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
                Title = "Simple ADO",
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

            trackFormModel.Artists = await GetArtistSelectionListAsync();
            trackFormModel.Customers = await GetCustomerSelectionListAsync();

            trackFormModel.TrackModels = await GetTrackModels(trackFormModel.ArtistId, trackFormModel.CustomerId);

            return View("TrackMVC", trackFormModel);
        }

        private async Task<IList<TrackModel>> GetTrackModels(string artistId, string customerId)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var connectionString = dbContext.Database.GetConnectionString();

                if (String.IsNullOrWhiteSpace(artistId) && String.IsNullOrWhiteSpace(customerId))
                    throw new ArgumentException("Must supply at least one of ArtistId or CustomerId");

                var query = new StringBuilder();

                query.Append("SELECT ");
                query.Append("	t.[Name] AS [TrackName], ");
                query.Append("	a.[Title] AS [AlbumTitle], ");
                query.Append("	ar.[Name] AS [ArtistName], ");
                query.Append("	t.[Composer] as [TrackComposer], ");
                query.Append("	c.[FirstName] AS [CustomerFirstName], ");
                query.Append("	c.[LastName] as [CustomerLastName] ");
                query.Append("FROM Track t ");
                query.Append("JOIN Album a ");
                query.Append("	ON a.AlbumId = t.AlbumId ");
                query.Append("JOIN Artist ar ");
                query.Append("	ON ar.ArtistId = a.ArtistId ");
                query.Append("JOIN InvoiceLine il ");
                query.Append("	ON il.TrackId = t.TrackId ");
                query.Append("JOIN Invoice i ");
                query.Append("	ON i.InvoiceId = il.InvoiceId ");
                query.Append("JOIN Customer c ");
                query.Append("	ON c.CustomerId = i.CustomerId ");

                if (!String.IsNullOrWhiteSpace(artistId))
                {
                    query.Append("WHERE a.[ArtistId] = @artistId ");
                    if (!String.IsNullOrWhiteSpace(customerId))
                    {
                        query.Append("AND ");
                        query.Append("EXISTS ( ");
                        query.Append("	SELECT 0 ");
                        query.Append("	FROM InvoiceLine il2 ");
                        query.Append("	JOIN Invoice i2 ");
                        query.Append("	ON il2.InvoiceId = i2.InvoiceId ");
                        query.Append("	WHERE il2.TrackId = t.TrackId ");
                        query.Append("	AND i2.CustomerId = @customerId ");
                        query.Append(") ");
                    }
                }
                else
                {
                    query.Append("WHERE ");
                    query.Append("EXISTS ( ");
                    query.Append("	SELECT 0 ");
                    query.Append("	FROM InvoiceLine il2 ");
                    query.Append("	JOIN Invoice i2 ");
                    query.Append("	ON il2.InvoiceId = i2.InvoiceId ");
                    query.Append("	WHERE il2.TrackId = t.TrackId ");
                    query.Append("	AND i2.CustomerId = @customerId ");
                    query.Append(") ");
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
                        var rdr = await cmd.ExecuteReaderAsync();
                        while (await rdr.ReadAsync())
                        {
                            var trackName = rdr.getValue<string>("TrackName");
                            var albumTitle = rdr.getValue<string>("AlbumTitle");
                            var artistName = rdr.getValue<string>("ArtistName");
                            var trackComposer = rdr.getValue<string>("TrackComposer");
                            var customerFirstName = rdr.getValue<string>("CustomerFirstName");
                            var customerLastName = rdr.getValue<string>("CustomerLastName");

                            var trackModel = trackModelList.SingleOrDefault(t => t.TrackName == trackName);

                            var addingNew = false;
                            if (trackModel == null)
                            {
                                trackModel = new TrackModel
                                {
                                    TrackName = trackName,
                                    ArtistName = artistName,
                                    AlbumTitle = albumTitle,
                                    TrackComposer = trackComposer
                                };

                                addingNew = true;
                            }

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

        private async Task<IEnumerable<SelectListItem>> GetArtistSelectionListAsync()
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
                        var rdr = await cmd.ExecuteReaderAsync();
                        while (await rdr.ReadAsync())
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

        private async Task<IEnumerable<SelectListItem>> GetCustomerSelectionListAsync()
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
                        var rdr = await cmd.ExecuteReaderAsync();
                        while (await rdr.ReadAsync())
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

        // #TODO: Move GetContentsAsync() someplace reasonable
        public async Task<string> GetContentsAsync(IWebHostEnvironment _webHostEnvironment, string path)
        {
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            var contents = await System.IO.File.ReadAllTextAsync(filepath);
            return contents;
        }
    }
}
