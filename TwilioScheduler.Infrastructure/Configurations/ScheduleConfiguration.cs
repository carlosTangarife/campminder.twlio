using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwilioScheduler.Domain.Entities;
using TwilioScheduler.Domain.ValueObjects;
using System.Text.Json;

namespace TwilioScheduler.Infrastructure.Persistence.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id);
            
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
                
            builder.Property(s => s.Description)
                .HasMaxLength(500);
                
            builder.Property(s => s.RecurrencePattern)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<RecurrencePattern>(v, new JsonSerializerOptions()));
                    
            builder.HasMany(s => s.Messages)
                .WithOne()
                .HasForeignKey(m => m.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}