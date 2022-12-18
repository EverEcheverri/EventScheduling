using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EventScheduling.Domain.Event;

namespace EventScheduling.Infrastructure.EntityFramework.Configurations;

internal static class InvitationEntityTypeConfiguration
{
  internal static void Configure(this EntityTypeBuilder<Invitation> builder)
  {
    builder.ToTable("Invitation")
      .HasKey(c => c.Id);

    builder.Property(c => c.Id).HasConversion<Guid>()
      .IsRequired();

    builder.Property(c => c.Email)
      .IsRequired()
      .HasMaxLength(300);

    builder.Property(c => c.Status)
      .IsRequired()
      .HasMaxLength(300);

    builder.Property(p => p.StartTime)
      .HasColumnName(nameof(Invitation.StartTime))
      .HasConversion(p => p, p => DateTime.SpecifyKind(p, DateTimeKind.Local));

    builder.Property(p => p.EndTime)
      .HasColumnName(nameof(Invitation.EndTime))
      .HasConversion(p => p, p => DateTime.SpecifyKind(p, DateTimeKind.Local));

    /*
   public Guid Id { get; set; }
   public string Email { get; set; }
   public string Status { get; set; }
   public DateTime StartTime { get; set; }
   public DateTime EndTime { get; set; }
     */
  }
}
