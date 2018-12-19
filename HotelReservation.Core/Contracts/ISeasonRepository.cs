namespace HotelReservation.Core.Contracts
{
    using HotelReservation.Core.Entities;
    using System;
    using System.Collections.Generic;

    public interface ISeasonRepository
    {
        ICollection<Season> GetAllSeasons();
        void AddSeason(Season season);
        Season GetSeasonById(long id);
        Season GetSeasonByDate(DateTime date);
        void UpdateSeason();
        void DeleteSeason(Season season);
    }
}
