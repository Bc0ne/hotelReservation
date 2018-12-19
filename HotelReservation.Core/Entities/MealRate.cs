namespace HotelReservation.Core.Entities
{
    using System;

    public class MealRate
    {
        public long Id { get; private set; }

        public Decimal Price { get; private set; }

        public long MealId { get; private set; }

        public long SeasonId { get; private set; }

        public Meal Meal { get; private set; }

        public Season Season { get; private set; }

        public static MealRate New(Decimal price, Season season, Meal meal)
        {
            return new MealRate
            {
                Price = price,
                Season = season,
                Meal = meal
            };
        }

        public void UpdateRate(decimal rate)
        {
            Price = rate;
        }
    }
}
