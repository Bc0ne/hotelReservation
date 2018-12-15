namespace HotelReservation.Data.Config
{
    using HotelReservation.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SeasonConfig : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Type)
                .IsRequired();

            builder
                .Property(x => x.StartingDate)
                .IsRequired();

            builder
                .Property(x => x.EndingDate)
                .IsRequired();

        }
    }
}
