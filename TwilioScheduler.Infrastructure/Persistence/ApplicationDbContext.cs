using Microsoft.EntityFrameworkCore;
using TwilioScheduler.Domain.Entities;
using TwilioScheduler.Infrastructure.Persistence.Configurations;

namespace TwilioScheduler.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduledMessage> ScheduledMessages { get; set; }
        public DbSet<MessageResponse> MessageResponses { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduledMessageConfiguration());
            modelBuilder.ApplyConfiguration(new MessageResponseConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}