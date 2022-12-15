namespace EventScheduling.Infrastructure.EntityFramework.Configurations;

using Domain.City;
using Domain.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
{
  public void Configure(EntityTypeBuilder<City> builder)
  {
    builder.ToTable("City")
      .HasKey(c => c.Id);

    builder.Property(c => c.Id)
      .HasConversion<Guid>(p => p, p => new GuidValueObject(p))
      .IsRequired();

    builder.Property(c => c.CountryId)
      .HasConversion<Guid>(p => p, p => new GuidValueObject(p))
      .IsRequired();

    builder.Property(c => c.Name)
      .IsRequired()
      .HasMaxLength(200);
  }
}
