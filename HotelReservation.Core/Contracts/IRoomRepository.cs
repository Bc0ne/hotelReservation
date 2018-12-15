using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Contracts
{
    public interface IRoomRepository
    {
        ICollection<Room> GetRooms();
        Room GetRoomById(long id);
        void AddRoom(Room room);
        void UpdateRoom();
    }
}
