namespace EventScheduling.Infrastructure.EntityFramework.Configurations;

using Domain.City;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
{
  public void Configure(EntityTypeBuilder<City> builder)
  {
    builder.ToTable("City")
      .HasKey(c => c.Id);

    builder.Property(c => c.Id).HasConversion<Guid>()
      .IsRequired();

    builder.Property(c => c.CountryId).HasConversion<Guid>()
      .IsRequired();

    builder.Property(c => c.Name)
      .IsRequired()
      .HasMaxLength(200);

    builder.Property(c => c.TimeZoneId)
      .IsRequired()
      .HasMaxLength(200);

    builder.HasMany(e => e.Users).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
    builder.Metadata.FindNavigation(nameof(City.Users))
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }
}
