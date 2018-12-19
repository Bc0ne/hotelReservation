namespace HotelReservation.Core.Entities
{
    using System;

    public class Reservation
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Country { get; private set; }

        public int Adults { get; private set; }

        public int Children { get; private set; }

        public long RoomId { get; private set; }

        public virtual Room Room { get; private set; }

        public long MealId { get; private set; }

        public virtual Meal Meal { get; private set; }

        public long SeasonId { get; private set; }

        public virtual Season Season { get; private set; }

        public DateTime CheckIn { get; private set; }

        public DateTime CheckOut { get; private set; }

        public Decimal TotalCost { get; private set; }

        public static Reservation New(string name,
            string email,
            string country,
            int adults,
            int children,
            Room room,
            Meal meal,
            Season season,
            DateTime checkIn,
            DateTime checkOut,
            decimal totalCost)
        {
            return new Reservation
            {
                Name = name,
                Email = email,
                Country = country,
                Adults = adults,
                Children = children,
                Room = room,
                Meal = meal,
                Season = season,
                CheckIn = checkIn,
                CheckOut = checkOut,
                TotalCost = totalCost
            };
        }

    }
}
