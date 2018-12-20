namespace HotelReservation.Core.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Season
    {
        public long Id { get; private set; }
        public string Type { get; private set; }
        public DateTime StartingDate { get; private set; }
        public DateTime EndingDate { get; private set; }
        public virtual ICollection<RoomRate> RoomRates { get; private set; }
        public virtual ICollection<MealRate> MealRates { get; private set; }

        public static Season New(string type, DateTime startingDate, DateTime endingDate)
        {
            return new Season
            {
                Type = type,
                StartingDate = startingDate,
                EndingDate = endingDate
            };
        }

        public void UpdateSeasonType(string type)
        {
            Type = type;
        }
    }
}
