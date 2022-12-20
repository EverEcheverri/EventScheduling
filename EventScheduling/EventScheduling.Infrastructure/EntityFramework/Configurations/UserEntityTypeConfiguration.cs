namespace EventScheduling.Infrastructure.EntityFramework.Configurations;

using Domain.User;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("Users")
      .HasKey(c => c.Id);

    builder.Property(c => c.Id).HasConversion<Guid>();

    builder.Property(c => c.Email)
      .HasConversion<string>(p => p, p => new Email(p))
      .HasMaxLength(254);
    builder.HasIndex(c => c.Email).IsUnique();

    builder.Property(c => c.Name)
      .HasConversion<string>(p => p, p => new UserName(p))
      .IsRequired()
      .HasMaxLength(255);

    builder.Property(c => c.Mobile)
      .HasConversion<string>(p => p, p => new Mobile(p))
      .IsRequired()
      .HasMaxLength(255);
  }
}
