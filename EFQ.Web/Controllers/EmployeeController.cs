using EFQ.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFQ.Web.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            // var employee = new Employee
            // {
            //     Name = "Joe"
            // };

            // return employee;
            return "This is my default action";
        }
    }
}