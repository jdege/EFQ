#define NO_SKIP

using System;
using System.Linq;
using System.Text;
#if NO_SKIP
using EFQ.Web.Models;
#endif
using Microsoft.AspNetCore.Mvc;

namespace EFQ.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private static Random random = new();

        [HttpGet]
        public string Index()
        {
#if NO_SKIP
            using (var dbContext = new ChinookContext())
            {
                var artist = new Artist
                {
                    Name = "Name" + random.Next()
                };

                dbContext.Artists.Add(artist);
                dbContext.SaveChanges();
            }
#endif

            StringBuilder sb = new();
            sb.AppendLine("These are the artists:");

#if NO_SKIP
            using (var dbContext = new ChinookContext())
            {
                var artists = dbContext.Artists.ToList();

                foreach (var artist in artists)
                {
                    sb.AppendLine($"{artist.Name}");
                }
            }
#endif

            return sb.ToString(); ;
        }
    }
}