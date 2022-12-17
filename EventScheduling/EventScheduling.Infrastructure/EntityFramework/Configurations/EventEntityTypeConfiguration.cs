namespace EventScheduling.Infrastructure.EntityFramework.Configurations;

using Domain.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
{
  public void Configure(EntityTypeBuilder<Event> builder)
  {
    builder.ToTable("Event")
      .HasKey(c => c.Id);

    builder.Property(c => c.Id).HasConversion<Guid>()
      .IsRequired();

    builder.Property(c => c.Name)
      .IsRequired()
      .HasMaxLength(300);

    builder.Property(c => c.Description)
      .IsRequired()
      .HasMaxLength(200);

    builder.Property(c => c.CityId).HasConversion<Guid>()
      .IsRequired();

    builder.Property(p => p.StartTime)
      .HasColumnName(nameof(Event.StartTime))
      .HasConversion(p => p, p => DateTime.SpecifyKind(p, DateTimeKind.Local));

    builder.Property(p => p.EndTime)
      .HasColumnName(nameof(Event.EndTime))
      .HasConversion(p => p, p => DateTime.SpecifyKind(p, DateTimeKind.Local));
  }
}
