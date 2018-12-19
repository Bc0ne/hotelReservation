namespace HotelReservation.Data.Repositories
{
    using HotelReservation.Core.Contracts;
    using HotelReservation.Core.Entities;
    using HotelReservation.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
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

        public Season GetSeasonById(long id)
        {
            return _context.Seasons.FirstOrDefault(x => x.Id == id);
        }

        public Season GetSeasonByDate(DateTime date)
        {
            return _context
                .Seasons
                .FirstOrDefault(x => x.StartingDate <= date && x.EndingDate >= date);
        }

        public void UpdateSeason()
        {
            _context.SaveChanges();
        }

        public void DeleteSeason(Season season)
        {
            _context.Seasons.Remove(season);
            _context.SaveChanges();
        }
    }
}
