using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            
            builder.Property(x => x.StartDate)
                .IsRequired();
            
            builder.Property(x => x.EndDate)
                .IsRequired();
            
            builder.Property(x => x.CheckedIn)
                .IsRequired()
                .HasDefaultValue(false);
            
            builder.Property(x => x.TotalCost)
                .IsRequired()
                .HasPrecision(9, 2);

            builder.HasOne(b => b.Guest)
            .WithMany(g => g.Bookings)
            .HasForeignKey(b => b.GuestId);

            builder.HasOne(b => b.Room)
            .WithOne()
            .HasForeignKey<Booking>(b => b.RoomId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}