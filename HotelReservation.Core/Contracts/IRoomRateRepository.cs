
namespace HotelReservation.Core.Contracts
{
    using HotelReservation.Core.Entities;
    using System;
    using System.Collections.Generic;

    public interface IRoomRateRepository
    {
        void AddRoomRate(RoomRate rate);
        ICollection<RoomRate> GetAllRoomRatesBySeasonId(long seasonId);
        ICollection<RoomRate> GetAllRoomRates();
        ICollection<Room> GetRoomsNotInSeasonById(long seasonId);
        RoomRate GetRoomRateBySeasonIdAndRoomId(long seasonId, long roomId);
        RoomRate GetRoomRateById(long id);
        void UpdateRoomRate();
        void Delete(RoomRate roomRate);
    }
}
