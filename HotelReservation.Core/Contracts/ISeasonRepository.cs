namespace HotelReservation.Core.Contracts
{
    using HotelReservation.Core.Entities;
    using System.Collections.Generic;

    public interface ISeasonRepository
    {
        ICollection<Season> GetAllSeasons();
        void AddSeason(Season season);
    }
}
