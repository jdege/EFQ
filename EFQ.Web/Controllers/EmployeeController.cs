
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
        private ChinookDbContext dbContext;

        public EmployeeController(ChinookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public string Index()
        {
            StringBuilder sb = new();
            sb.AppendLine("These are the artists:");

            //using (var dbContext = new ChinookDbContext())
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