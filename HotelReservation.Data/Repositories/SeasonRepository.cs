namespace HotelReservation.Data.Repositories
{
    using HotelReservation.Core.Contracts;
    using HotelReservation.Core.Entities;
    using HotelReservation.Data.Context;
    using System.Collections.Generic;
    using System.Linq;

    public class SeasonRepository : ISeasonRepository
    {
        private readonly ReservationContext _context;

        public SeasonRepository(ReservationContext context)
        {
            _context = context;
        }

        public ICollection<Season> GetAllSeasons()
        {
            return _context.Seasons.ToList();
        }

        public void AddSeason(Season season)
        {
            _context.Seasons.Add(season);
            _context.SaveChanges();
        }
    }
}
