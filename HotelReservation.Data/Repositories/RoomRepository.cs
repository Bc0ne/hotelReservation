using HotelReservation.Core.Contracts;
using HotelReservation.Core.Entities;
using HotelReservation.Data.Context;
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
    }
}
