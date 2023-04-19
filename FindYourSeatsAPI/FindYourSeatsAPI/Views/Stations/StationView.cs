using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindYourSeatsAPI.Views.Stations
{
    public class StationView : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
