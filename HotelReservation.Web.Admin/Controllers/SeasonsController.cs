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
    [Route("seasons")]
    public class SeasonsController : Controller
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IRoomRateRepository _roomRateRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMealRateRepository _mealRateRepository;
        private readonly IMealRepository _mealRepository;


        public SeasonsController(ISeasonRepository seasonRepository,
            IRoomRateRepository roomRateRepository,
            IRoomRepository roomRepository,
            IMealRateRepository mealRateRepository,
            IMealRepository mealRepository)
        {
            _seasonRepository = seasonRepository;
            _roomRateRepository = roomRateRepository;
            _roomRepository = roomRepository;
            _mealRateRepository = mealRateRepository;
            _mealRepository = mealRepository;
        }

        [HttpGet]
        [Route("all")]
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
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Message")))
            {
                ViewBag.Message = HttpContext.Session.GetString("Message");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SeasonInputModel model)
        {
            if (model.StartingDate.Date >= model.EndingDate.Date || model.StartingDate.Date < DateTime.Now.Date)
            {
                HttpContext.Session.SetString("Message", "Please enter valid String and Ending Dates");
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                var season = Season.New(model.SeasonType, model.StartingDate, model.EndingDate);

                _seasonRepository.AddSeason(season);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Edit(long id)
        {
            var season = _seasonRepository.GetSeasonById(id);
            var updateSeasonOutputModel = new UpdateSeasonInputModel();
            updateSeasonOutputModel.Type = season.Type;
            ViewBag.SeasonId = id;

            return View("UpdateSeason", updateSeasonOutputModel);
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdateSeasonInputModel model)
        {
            if (ModelState.IsValid)
            {
                var season = _seasonRepository.GetSeasonById(id);
                season.Type = model.Type;
                _seasonRepository.UpdateSeason();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        [Route("{id}/delete")]
        public ActionResult Delete(int id)
        {
            var season = _seasonRepository.GetSeasonById(id);
            _seasonRepository.DeleteSeason(season);

            ViewBag.Message = season.Type + "has been deleted.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("{id}/roomrates/all")]
        public IActionResult GetAllRoomRatesBySeason(long id)
        {
            var season = _seasonRepository.GetSeasonById(id);

            var roomRates = _roomRateRepository.GetAllRoomRatesBySeasonId(season.Id);

            var roomRatesBySeasonOutputModel = new List<RoomRateViewModel>();

            foreach (var rate in roomRates)
            {
                roomRatesBySeasonOutputModel.Add(new RoomRateViewModel()
                {
                    RateId = rate.Id,
                    RoomType = rate.Room.Type,
                    SeasonType = rate.Season.Type,
                    Rate = rate.Price,
                    From = rate.Season.StartingDate,
                    To = rate.Season.EndingDate
                });
            }
            SeasonViewModel seasonOutputModel = new SeasonViewModel()
            {
                Id = season.Id,
                SeasonType = season.Type,
                StartingDate = season.StartingDate,
                EndingDate = season.EndingDate
            };

            ViewBag.Season = season;
            return View("RoomRates", roomRatesBySeasonOutputModel);
        }

        [HttpGet]
        [Route("{id}/roomrates")]
        public IActionResult AddRoomRateToSeason(long id)
        {
            var rooms = _roomRateRepository.GetRoomsNotInSeasonById(id);
            var roomsOutputModel = new List<RoomRateOutputModel>();
            foreach (var room in rooms)
            {
                roomsOutputModel.Add(new RoomRateOutputModel
                {
                    Id = room.Id,
                    Type = room.Type
                });
            }

            ViewBag.Rooms = roomsOutputModel;
            ViewBag.SeasonId = id;
            return View("CreateRoomRate");
        }

        [HttpPost]
        [Route("{id}/roomrates")]
        [ValidateAntiForgeryToken]
        public IActionResult AddRoomRateToSeason(long seasonId, RoomRateInputModel model)
        {
            if (ModelState.IsValid)
            {
                var season = _seasonRepository.GetSeasonById(seasonId);
                var room = _roomRepository.GetRoomById(model.Room.Id);
                var roomRate = RoomRate.New(model.Rate, season, room);

                _roomRateRepository.AddRoomRate(roomRate);

                return RedirectToAction("GetAllRoomRatesBySeason", new { id = seasonId });
            }

            return RedirectToRoute("roomRates", new { id = seasonId });
        }

        [HttpGet]
        [Route("{id}/roomrates/{rateId}")]
        public IActionResult EditRoomRateForSeason(long id, long rateId)
        {
            var roomRate = _roomRateRepository.GetRoomRateById(rateId);
            var roomRateOutputModel = new RoomRateUpdateInputModel()
            {
                RoomRateId = rateId,
                SeasonId = id,
                Rate = roomRate.Price
            };

            return View(roomRateOutputModel);
        }

        [HttpPost]
        [Route("{id}/roomrates/{rateId}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateRoomRateForSeason(long id, long rateId, RoomRateUpdateInputModel model)
        {
            var roomRate = _roomRateRepository.GetRoomRateById(rateId);

            roomRate.UpdateRate(model.Rate);
            _roomRateRepository.UpdateRoomRate();

            return RedirectToAction("EditRoomRateForSeason", new { id = id, rateId = rateId });
        }

        [HttpGet]
        [Route("{id}/roomrates/{rateId}/delete")]
        public IActionResult DeleteRoomRate(long id, long rateId)
        {
            var roomRate = _roomRateRepository.GetRoomRateById(rateId);

            _roomRateRepository.Delete(roomRate);

            return RedirectToAction(nameof(GetAllRoomRatesBySeason), new { id = id});
        }


        [HttpGet]
        [Route("{id}/mealrates/all")]
        public IActionResult GetAllMealRatesBySeason(long id)
        {
            var season = _seasonRepository.GetSeasonById(id);

            var mealRates = _mealRateRepository.GetAllMealRatesBySeasonId(season.Id);

            var mealRatesBySeasonOutputModel = new List<MealRateViewModel>();

            foreach (var rate in mealRates)
            {
                mealRatesBySeasonOutputModel.Add(new MealRateViewModel()
                {
                    MealId = rate.Id,
                    MealType = rate.Meal.Type,
                    Rate = rate.Price,
                    From = rate.Season.StartingDate,
                    To = rate.Season.EndingDate
                });
            }

            ViewBag.Season = season;
            return View("MealRates", mealRatesBySeasonOutputModel);
        }

        [HttpGet]
        [Route("{id}/mealrates")]
        public IActionResult AddMealRateToSeason(long id)
        {
            var meals = _mealRateRepository.GetMealsNotInSeasonById(id);
            var mealsOutputModel = new List<MealRateOutputModel>();
            foreach (var meal in meals)
            {
                mealsOutputModel.Add(new MealRateOutputModel
                {
                    Id = meal.Id,
                    Type = meal.Type
                });
            }

            ViewBag.Meals = mealsOutputModel;
            ViewBag.SeasonId = id;
            return View("CreateMealRate");
        }

        [HttpPost]
        [Route("{id}/mealrates")]
        [ValidateAntiForgeryToken]
        public IActionResult AddMealRateToSeason(long seasonId, MealRateInputModel model)
        {
            if (ModelState.IsValid)
            {
                var season = _seasonRepository.GetSeasonById(seasonId);
                var meal = _mealRepository.GetMealById(model.MealId);
                var mealRate = MealRate.New(model.Rate, season, meal);

                _mealRateRepository.AddMealRate(mealRate);

                return RedirectToAction(nameof(GetAllMealRatesBySeason), new { id = seasonId });
            }

            return RedirectToAction(nameof(AddMealRateToSeason), new { id = seasonId });
        }

        [HttpGet]
        [Route("{id}/mealrates/{rateId}")]
        public IActionResult EditMealRateForSeason(long id, long rateId)
        {
            var mealRate = _mealRateRepository.GetMealRateById(rateId);

            var mealRateOutputModel = new MealRateUpdateInputModel()
            {
                MealRateId = rateId,
                SeasonId = id,
                Rate = mealRate.Price
            };

            return View(mealRateOutputModel);
        }

        [HttpPost]
        [Route("{id}/mealrates/{rateId}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMealRateForSeason(long id, long rateId, MealRateUpdateInputModel model)
        {
            var mealRate = _mealRateRepository.GetMealRateById(rateId);

            mealRate.UpdateRate(model.Rate);

            _mealRateRepository.UpdateRate();

            return RedirectToAction(nameof(GetAllMealRatesBySeason), new { id = id });
        }

        [HttpGet]
        [Route("{id}/mealrates/{rateId}/delete")]
        public IActionResult DeleteMealRateById(long id, long rateId)
        {
            var mealRate = _mealRateRepository.GetMealRateById(rateId);

            _mealRateRepository.Delete(mealRate);

            return RedirectToAction(nameof(GetAllMealRatesBySeason), new { id = id});
        }
    }
}