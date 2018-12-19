namespace HotelReservation.Core.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Season
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public virtual ICollection<RoomRate> RoomRates { get; set; }
        public virtual ICollection<MealRate> MealRates { get; set; }

        public static Season New(string type, DateTime startingDate, DateTime endingDate)
        {
            return new Season
            {
                Type = type,
                StartingDate = startingDate,
                EndingDate = endingDate
            };
        }
    }
}
