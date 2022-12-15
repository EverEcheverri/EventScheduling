namespace EventScheduling.Infrastructure.EntityFramework.Configurations;

using Domain.Team;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
{
  public void Configure(EntityTypeBuilder<Team> builder)
  {
    builder.ToTable("Team")
      .HasKey(c => c.Id);

    builder.Property(c => c.Id).HasConversion<Guid>();

    builder.Property(c => c.Name)
      .HasColumnName("Name")
      .IsRequired()
      .HasMaxLength(100);
  }
}
