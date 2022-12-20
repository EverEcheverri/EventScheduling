namespace EventScheduling.Infrastructure.EntityFramework.Configurations;

using Domain.Country;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
{
  public void Configure(EntityTypeBuilder<Country> builder)
  {
    builder.ToTable("Country")
      .HasKey(c => c.Id);

    builder.Property(c => c.Id).HasConversion<Guid>()
      .IsRequired();

    builder.Property(c => c.Name)
      .IsRequired()
      .HasMaxLength(100);

    builder.HasMany(c => c.Cities);
  }
}
