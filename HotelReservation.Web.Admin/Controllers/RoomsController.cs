namespace HotelReservation.Web.Admin.Controllers
{
    using HotelReservation.Core.Contracts;
    using HotelReservation.Core.Entities;
    using HoteReservation.Web.Models.Room;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("rooms/")]
    public class RoomsController : Controller
    {
        public readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        [Route("all", Name ="allRooms")]
        public ActionResult Index()
        {
            var rooms = _roomRepository.GetRooms();

            List<RoomViewModel> roomsOutputModel = new List<RoomViewModel>();

            foreach(var room in rooms)
            {
                roomsOutputModel.Add(new RoomViewModel()
                {
                    Id = room.Id,
                    RoomType = room.Type,
                    NumberOfAdults = room.MaxNumOfAdults,
                    NumberOfChildren = room.MaxNumOfChildren
                });
            }

            return View(roomsOutputModel);
        }

        [HttpGet]
        public IActionResult CreateRoom()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Message")))
            {
                ViewBag.Message = HttpContext.Session.GetString("Message");
                HttpContext.Session.Remove("Message");
            }

            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRoom(RoomInputModel model)
        {
            if (ModelState.IsValid)
            {
                if ((model.MaxNumOfAdults <= 0 && model.MaxNumOfChildren <= 0) || model.MaxNumOfAdults < 0 || model.MaxNumOfChildren < 0)
                {
                    HttpContext.Session.SetString("Message", "Please check Room capacity for Adults and Children.");
                    return RedirectToAction(nameof(CreateRoom));
                }

                var room = Room.New(model.RoomType, model.MaxNumOfAdults, model.MaxNumOfChildren);

                _roomRepository.AddRoom(room);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult EditRoom(long id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Message")))
            {
                ViewBag.Message = HttpContext.Session.GetString("Message");
                HttpContext.Session.Remove("Message");
            }

            var room = _roomRepository.GetRoomById(id);

            var roomOutputModel = new RoomViewModel()
            {
                Id = room.Id,
                RoomType = room.Type,
                NumberOfAdults = room.MaxNumOfAdults,
                NumberOfChildren = room.MaxNumOfChildren
            };
            ViewBag.RoomId = id;
            return View("Edit", roomOutputModel);
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditRoom(int id, RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((model.NumberOfAdults <= 0 && model.NumberOfChildren <= 0) || model.NumberOfAdults < 0 || model.NumberOfChildren < 0)
                {
                    HttpContext.Session.SetString("Message", "Please check Adults and Children entries.");
                    return RedirectToAction(nameof(EditRoom), new { id = id});
                }

                var room = _roomRepository.GetRoomById(id);

                room.Update(model.RoomType, model.NumberOfAdults, model.NumberOfChildren);

                _roomRepository.UpdateRoom();

                return RedirectToAction(nameof(Index));
            }

            return View("Edit");
        }

        [HttpGet]
        [Route("{id}/delete", Name ="deleteRoom")]
        public ActionResult DeleteRoom(long id)
        {
            var room = _roomRepository.GetRoomById(id);
            _roomRepository.DeleteRoom(room);
            ViewBag.Message = room.Type + "has been deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}