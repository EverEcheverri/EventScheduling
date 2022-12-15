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

    builder.Property(c => c.Id).HasConversion<Guid>();

    builder.Property(c => c.Name)
      .HasColumnName("Name")
      .IsRequired()
      .HasMaxLength(200);
  }
}
