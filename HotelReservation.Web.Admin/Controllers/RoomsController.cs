namespace HotelReservation.Web.Admin.Controllers
{
    using HotelReservation.Core.Contracts;
    using HotelReservation.Core.Entities;
    using HoteReservation.Web.Models.Room;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class RoomsController : Controller
    {
        public readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomInputModel model)
        {
            if (ModelState.IsValid)
            {

                var room = Room.New(model.RoomType, model.MaxNumOfAdults, model.MaxNumOfChildren);

                _roomRepository.AddRoom(room);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var room = _roomRepository.GetRoomById(id);

            var roomOutputModel = new RoomViewModel()
            {
                Id = room.Id,
                RoomType = room.Type,
                NumberOfAdults = room.MaxNumOfAdults,
                NumberOfChildren = room.MaxNumOfChildren
            };

            return View(roomOutputModel);
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var room = _roomRepository.GetRoomById(id);

                room.Update(model.RoomType, model.NumberOfAdults, model.NumberOfChildren);

                _roomRepository.UpdateRoom();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rooms/Delete/5
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