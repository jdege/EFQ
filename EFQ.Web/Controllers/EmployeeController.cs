using System;
using System.Linq;
using System.Text;
using EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFQ.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private static Random random = new();

        [HttpGet]
        public string Index()
        {
            using (var dbContext = new ChinookContext())
            {
                var artist = new Artist
                {
                    Name = "Name" + random.Next()
                };

                dbContext.Artists.Add(artist);
                dbContext.SaveChanges();
            }

            StringBuilder sb = new();

            using (var dbContext = new ChinookContext())
            {
                var artists = dbContext.Artists.ToList();

                foreach (var artist in artists)
                {
                    sb.AppendLine($"{artist.Name}");
                }
            }

            return sb.ToString(); ;
        }
    }
}