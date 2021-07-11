//#define SKIP_STUFF

using System;
using System.Linq;
using System.Text;
#if SKIP_STUFF
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
#if SKIP_STUFF
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

#if SKIP_STUFF
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