namespace HotelReservation.Data.Config
{
    using HotelReservation.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoomRateConfig : IEntityTypeConfiguration<RoomRate>
    {
        public void Configure(EntityTypeBuilder<RoomRate> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //builder
            //    .HasKey(x => new { x.Id, x.RoomId, x.SeasonId });

            builder
                .Property(x => x.Price)
                .HasColumnType("Money");
        }
    }
}
