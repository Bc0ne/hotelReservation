using HotelReservation.Core.Contracts;
using HotelReservation.Core.Entities;
using HotelReservation.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ReservationContext _context;

        public RoomRepository(ReservationContext context)
        {
            _context = context;
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public Room GetRoomById(long id)
        {
            return _context.Rooms.SingleOrDefault(r => r.Id == id);
        }

        public ICollection<Room> GetRooms()
        {
            return _context.Rooms.ToList();
        }

        public void UpdateRoom()
        {
            _context.SaveChanges();
        }

        public ICollection<Room> GetRoomsBySeasonDate(DateTime date)
        {
            var rooms = _context.Rooms
                .Where(r => _context.RoomRates
               .Where(x => x.Season.StartingDate <= date && x.Season.EndingDate >= date)
               .Select(x => x.Room.Id)
               .Contains(r.Id)).ToList();

            return rooms;
        }

        public void DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}
