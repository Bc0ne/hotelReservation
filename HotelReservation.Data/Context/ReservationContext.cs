namespace HotelReservation.Data.Context
{
    using HotelReservation.Core.Entities;
    using HotelReservation.Data.Config;
    using Microsoft.EntityFrameworkCore;

    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options)
            :base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<RoomRate> RoomRates { get; set; }
        public DbSet<MealRate> MealRates { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new RoomConfig())
                .ApplyConfiguration(new MealConfig())
                .ApplyConfiguration(new SeasonConfig())
                .ApplyConfiguration(new RoomRateConfig())
                .ApplyConfiguration(new MealRateConfig())
                .ApplyConfiguration(new ReservationConfig());
        }
    }
}
