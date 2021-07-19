using System.Linq;
using System.Threading.Tasks;
using EFQ.Web.DbContexts;
using EFQ.Web.Entities;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JDege.EFQ.Web.Controllers
{
    public class RunQueryController : Controller
    {
        private readonly IDbContextFactory<ChinookContext> _contextFactory;

        public RunQueryController(IDbContextFactory<ChinookContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpGet]
        [Route("[Controller]/{id}")]
        public async Task<IActionResult> IndexAsync(int id)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQuery = await dbContext.StoredQueries.SingleOrDefaultAsync(q => q.StoredQueryId == id);
                if (storedQuery == null)
                {
                    return NotFound();
                }

                var efq = JsonConvert.DeserializeObject<EFQ>(storedQuery.StoredQueryJson);
                var predicate = efq.ConstructSinglePredicate<Album>(null);

                var albums = await dbContext.Albums
                    .Include(a => a.Artist)
                    .Where(predicate).ToListAsync();

                // #TODO: Use AutoMapper!!!
                var albumModels = albums.Select(a => new AlbumModel
                {
                    Id = a.AlbumId,
                    Title = a.Title,
                    ArtistName = a.Artist.Name
                });

                return View(albumModels);
            }
        }
    }
}
