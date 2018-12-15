using System;

namespace HotelReservation.Core.Entities
{
    public class Meal
    {
        public long Id { get; private set; }
        public string Type { get; private set; }

        public static Meal New(string type)
        {
            return new Meal
            {
                Type = type
            };
        }

        public void Update(string mealType)
        {
            Type = mealType;
        }
    }
}
