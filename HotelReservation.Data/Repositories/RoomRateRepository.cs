namespace HotelReservation.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using HotelReservation.Core.Contracts;
    using HotelReservation.Core.Entities;
    using HotelReservation.Data.Context;
    using Microsoft.EntityFrameworkCore;

    public class RoomRateRepository : IRoomRateRepository
    {
        private readonly ReservationContext _context;

        public RoomRateRepository(ReservationContext context)
        {
            _context = context;
        }

        public void AddRoomRate(RoomRate rate)
        {
            _context.RoomRates.Add(rate);
            _context.SaveChanges();
        }

        public ICollection<RoomRate> GetAllRoomRates()
        {
            return _context
                .RoomRates
                .Include(x => x.Room)
                .Include(x => x.Season)
                .OrderBy(x => x.RoomId).ToList();
        }

        public ICollection<RoomRate> GetAllRoomRatesBySeasonId(long seasonId)
        {
            return _context
                .RoomRates
                .Include(x => x.Room)
                .Include(x => x.Season)
                .Where(x => x.SeasonId == seasonId)
                .OrderBy(x => x.RoomId).ToList();
        }

        public RoomRate GetRoomRateBySeasonIdAndRoomId(long seasonId, long roomId)
        {
            return _context.RoomRates.Where(x => x.SeasonId == seasonId && x.RoomId == roomId).FirstOrDefault();
        }

        public ICollection<Room> GetRoomsNotInSeasonById(long seasonId)
        {
            var rooms = _context.Rooms
                .Where(r => !_context.RoomRates
               .Where(x => x.SeasonId == seasonId)
               .Select(x => x.Room.Id)
               .Contains(r.Id)).ToList();

            return rooms;
        }

        public void UpdateRoomRate()
        {
            _context.SaveChanges();
        }

        public void Delete(RoomRate roomRate)
        {
            _context.RoomRates.Remove(roomRate);
            _context.SaveChanges();
        }

        public RoomRate GetRoomRateById(long id)
        {
            return _context.RoomRates.FirstOrDefault(x => x.Id == id);
        }
    }
}
