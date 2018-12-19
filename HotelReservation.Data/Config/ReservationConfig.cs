namespace HotelReservation.Data.Config
{
    using HotelReservation.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .IsRequired();

            builder
                .Property(x => x.Country)
                .IsRequired();

            builder
                .Property(x => x.CheckIn)
                .IsRequired();

            builder
                .Property(x => x.CheckOut)
                .IsRequired();
        }
    }
}
