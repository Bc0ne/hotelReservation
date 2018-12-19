using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Entities
{
    public class Room
    {
        public long Id { get; private set; }
        public string Type { get; private set; }
        public int MaxNumOfAdults { get; private set; }
        public int MaxNumOfChildren { get; private set; }

        public static Room New(string roomType, int maxNumOfAdults, int maxNumOfChildren)
        {
            return new Room()
            {
                Type = roomType,
                MaxNumOfAdults = maxNumOfAdults,
                MaxNumOfChildren = maxNumOfChildren
            };
        }

        public void Update(string roomType, int maxNumOfAdults, int maxNumOfChildren)
        {
            Type = roomType;
            MaxNumOfAdults = maxNumOfAdults;
            MaxNumOfChildren = maxNumOfChildren;
        }
    }
}
