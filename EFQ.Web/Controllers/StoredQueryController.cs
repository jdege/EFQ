using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFQ.Web.DbContexts;
using EFQ.Web.Entities;
using JDege.EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JDege.EFQ.Web.Controllers
{
    public class StoredQueryController : Controller
    {
        private readonly IDbContextFactory<ChinookContext> _contextFactory;
        private readonly IMapper _mapper;

        public StoredQueryController(IDbContextFactory<ChinookContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var storedQueries = await dbContext.StoredQueries.ToListAsync();

                var storedQueryModels = _mapper.Map<IEnumerable<StoredQuery>, List<StoredQueryModel>>(storedQueries);

                return View(storedQueryModels);
            }
        }
    }
}
