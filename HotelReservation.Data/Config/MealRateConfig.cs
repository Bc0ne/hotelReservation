namespace HotelReservation.Data.Config
{
    using HotelReservation.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MealRateConfig : IEntityTypeConfiguration<MealRate>
    {
        public void Configure(EntityTypeBuilder<MealRate> builder)
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
