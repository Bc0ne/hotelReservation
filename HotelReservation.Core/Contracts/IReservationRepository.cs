namespace HotelReservation.Core.Contracts
{
    using HotelReservation.Core.Entities;

    public interface IReservationRepository
    {
        void SaveReservation(Reservation reservation);
        decimal CalculateReservationCost(int numOfRooms, int numOfDays, int numOfGuests, decimal price1, decimal price2);
    }
}
