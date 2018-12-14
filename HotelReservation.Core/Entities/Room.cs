namespace HotelReservation.Core.Entities
{
    public class Room
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public int MaxNumOfAdults { get; set; }
        public int MaxNumOfChildren { get; set; }
    }
}
