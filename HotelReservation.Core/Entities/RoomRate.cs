using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Core.Entities
{
    public class RoomRate
    {
        public long Id { get; private set; }

        public Decimal Price { get; private set; }

        public long RoomId { get; private set; }

        public long SeasonId { get; private set; }

        public Room Room { get; private set; }

        public Season Season { get; private set; }

        public static RoomRate New(Decimal price, Season season, Room room)
        {
            return new RoomRate
            {
                Price = price,
                Season = season,
                Room = room
            };
        }

        public void UpdateRate(Decimal rate)
        {
            Price = rate;
        }
    }
}
