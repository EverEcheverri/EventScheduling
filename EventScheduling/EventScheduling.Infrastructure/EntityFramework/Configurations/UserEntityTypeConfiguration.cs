using Microsoft.EntityFrameworkCore;

namespace EventScheduling.Infrastructure.EntityFramework.Configurations;

using Domain.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("Users")
      .HasKey(c => c.Email);

    builder.Property(c => c.Name)
      .HasColumnName("Name")
      .IsRequired()
      .HasMaxLength(255);

    builder.Property(c => c.CityId)
      .HasColumnName("CityId")
      .HasConversion<Guid>()
      .IsRequired()
      .HasMaxLength(255);

    builder.Property(c => c.Mobile)
      .HasColumnName("Mobile")
      .IsRequired()
      .HasMaxLength(255);
  }
}
