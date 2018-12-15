using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservation.Core.Contracts;
using HotelReservation.Core.Entities;
using HoteReservation.Web.Models.Season;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Web.Admin.Controllers
{
    public class SeasonsController : Controller
    {
        public readonly ISeasonRepository _seasonRepository;

        public SeasonsController(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public ActionResult Index()
        {
            var seasons = _seasonRepository.GetAllSeasons();

            List<SeasonViewModel> seasonsOutputModel = new List<SeasonViewModel>();

            foreach (var season in seasons)
            {
                seasonsOutputModel.Add(new SeasonViewModel()
                {
                    Id = season.Id,
                    SeasonType = season.Type,
                    StartingDate = season.StartingDate,
                    EndingDate = season.EndingDate
                });
            }

            return View(seasonsOutputModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SeasonInputModel model)
        {
            if (ModelState.IsValid)
            {

                var season = Season.New(model.SeasonType, model.StartingDate, model.EndingDate);

                _seasonRepository.AddSeason(season);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Seasons/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Seasons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Seasons/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Seasons/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}