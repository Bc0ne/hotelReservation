
namespace HotelReservation.Data.Repositories
{
    using HotelReservation.Core.Contracts;
    using HotelReservation.Core.Entities;
    using HotelReservation.Data.Context;

    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext _context;

        public ReservationRepository(ReservationContext context)
        {
            _context = context;
        }

        public decimal CalculateReservationCost(int numOfRooms, int numOfDays, int numOfGuests, decimal roomRate, decimal mealRate)
        {
            var priceOfRooms = numOfRooms * (numOfDays * roomRate);
            var priceOfMeals = numOfGuests * mealRate * numOfDays;

            return (priceOfRooms + priceOfMeals);
        }

        public void SaveReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }


    }
}
