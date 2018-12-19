namespace HotelReservation.Web.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using HotelReservation.Web.Admin.Models;
    using HotelReservation.Core.Contracts;
    using HoteReservation.Web.Models.Season;
    using HoteReservation.Web.Models.Reservation;
    using HotelReservation.Core.Entities;
    using Microsoft.AspNetCore.Http;

    public class HomeController : Controller
    {
        private readonly IRoomRateRepository _roomRateRepository;
        private readonly IMealRateRepository _mealRateRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMealRepository _mealRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IReservationRepository _reservationRepository;

        public HomeController(IRoomRateRepository roomRateRepository,
            IMealRateRepository mealRateRepository,
            IRoomRepository roomRepository,
            IMealRepository mealRepository,
            ISeasonRepository seasonRepository,
            IReservationRepository reservationRepository)
        {
            _roomRateRepository = roomRateRepository;
            _mealRateRepository = mealRateRepository;
            _roomRepository = roomRepository;
            _mealRepository = mealRepository;
            _seasonRepository = seasonRepository;
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Message")))
            {
                ViewBag.Message = HttpContext.Session.GetString("Message");
                HttpContext.Session.Remove("Message");
            }

            var rooms = _roomRepository.GetRoomsBySeasonDate(DateTime.Now);
            var meals = _mealRepository.GetMealsBySeasonDate(DateTime.Now);
            var roomsOutputModel = new List<RoomRateOutputModel>();
            var mealsOutputModel = new List<MealRateOutputModel>();
            foreach (var room in rooms)
            {
                roomsOutputModel.Add(new RoomRateOutputModel
                {
                    Id = room.Id,
                    Type = room.Type
                });
            }

            ViewBag.Rooms = rooms;
            foreach (var meal in meals)
            {
                mealsOutputModel.Add(new MealRateOutputModel
                {
                    Id = meal.Id,
                    Type = meal.Type
                });
            }

            ViewBag.Rooms = roomsOutputModel;
            ViewBag.Meals = mealsOutputModel;
            return View("Reservation");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("reservation")]
        public IActionResult CreateNewReservation(ReservationInputModel model)
        {
            if (model.CheckIn.Date >= model.CheckOut.Date || model.CheckIn.Date < DateTime.Now.Date)
            {
                HttpContext.Session.SetString("Message", "Please enter valid CheckIn and CheckOut Dates");
                return RedirectToAction(nameof(Index));
            }

            if ((model.Adults <= 0 && model.Children <= 0) || model.Adults < 0 || model.Children < 0)
            {
                HttpContext.Session.SetString("Message", "Please check Room capacity for Adults and Children.");
                return RedirectToAction(nameof(Index));
            }

            var season = _seasonRepository.GetSeasonByDate(DateTime.Now);
            var room = _roomRepository.GetRoomById(model.RoomId);
            var meal = _mealRepository.GetMealById(model.MealId);

            var roomRateBySeasonIdAndRoomId = _roomRateRepository.GetRoomRateBySeasonIdAndRoomId(season.Id, model.RoomId);
            var mealRateBySeasonIdAndRoomId = _mealRateRepository.GetMealRateBySeasonIdAndRoomId(season.Id, model.MealId);

            var numOfRoomsForAdults = model.Adults / room.MaxNumOfAdults + (model.Adults % room.MaxNumOfAdults > 0 ? 1 : 0);
            var numOfRoomsForChildren = model.Children / room.MaxNumOfChildren + (model.Children % room.MaxNumOfChildren > 0 ? 1 : 0);
            var numOfRooms = numOfRoomsForAdults > numOfRoomsForChildren ? numOfRoomsForAdults : numOfRoomsForChildren;
            var numOfDays = model.CheckOut.Subtract(model.CheckIn).Days;

            var total = _reservationRepository.CalculateReservationCost(numOfRooms,
                numOfDays,model.Adults + model.Children,
                roomRateBySeasonIdAndRoomId.Price,
                mealRateBySeasonIdAndRoomId.Price);

            var reservation = Reservation.New(model.Name,
                model.Email,
                model.Country,
                model.Adults,
                model.Children,
                room,
                meal,
                season,
                model.CheckIn,
                model.CheckOut,
                total);

            _reservationRepository.SaveReservation(reservation);

            total = decimal.Round(total, 4);

            ViewBag.Total = total;

            return View("SuccessReservation", model);
        }
    }
}
