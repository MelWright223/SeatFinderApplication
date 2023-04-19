using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindYourSeatsAPI.Models;

namespace FindYourSeatsAPI.Controllers
{
    
    public class StationController : Controller
    {
        public IActionResult Index()
        {
            StationDataContext context = HttpContext.RequestServices.GetService(typeof(FindYourSeatsAPI.Models.StationDataContext)) as StationDataContext;
            return View(context.getAllStations());
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value" };
        }

    }
}
