using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class GuestConfig : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("Guests");
            builder.HasKey(g => g.Id);
            
            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(g => g.Bookings)
            .WithOne(b => b.Guest)
            .HasForeignKey(b => b.GuestId);
        }
    }
}