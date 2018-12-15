using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservation.Web.Admin.Models;
using HotelReservation.Core.Contracts;

namespace HotelReservation.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        public readonly IRoomRepository _roomRepository;

        public HomeController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Reservation page";
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
