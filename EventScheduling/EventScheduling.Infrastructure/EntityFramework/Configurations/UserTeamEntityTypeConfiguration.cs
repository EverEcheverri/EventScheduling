namespace EventScheduling.Infrastructure.EntityFramework.Configurations;

using Domain.UserTeam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserTeamEntityTypeConfiguration : IEntityTypeConfiguration<UserTeam>
{
  public void Configure(EntityTypeBuilder<UserTeam> builder)
  {
    builder.ToTable("UserTeam")
      .HasKey(c => new { c.TeamId, c.Email});

    builder.Property(c => c.TeamId).HasConversion<Guid>();
  }
}
