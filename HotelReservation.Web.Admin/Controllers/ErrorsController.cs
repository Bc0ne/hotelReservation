using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Web.Admin.Controllers
{
    [Route("errors")]
    public class ErrorsController : Controller
    {
        
        [HttpGet]
        [Route("500")]
        public IActionResult AppError()
        {
            return View();
        }

        [HttpGet]
        [Route("404")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}