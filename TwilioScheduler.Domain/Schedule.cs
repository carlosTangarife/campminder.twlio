using TwilioScheduler.Domain.Enums;
using TwilioScheduler.Domain.ValueObjects;

namespace TwilioScheduler.Domain.Entities
{
    public class Schedule
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }
        public ScheduleStatus Status { get; private set; }
        public RecurrencePattern RecurrencePattern { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public ICollection<ScheduledMessage> Messages { get; private set; }
        
        // For EF
        private Schedule() {}
        
        public Schedule(
            string name, 
            string description, 
            DateTime startDate, 
            RecurrencePattern recurrencePattern = null, 
            DateTime? endDate = null)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            RecurrencePattern = recurrencePattern;
            Status = ScheduleStatus.Active;
            CreatedAt = DateTime.UtcNow;
            Messages = new List<ScheduledMessage>();
        }
        
        public void AddMessage(ScheduledMessage message)
        {
            Messages.Add(message);
        }
        
        public void Deactivate()
        {
            Status = ScheduleStatus.Inactive;
            ModifiedAt = DateTime.UtcNow;
        }
        
        public void Activate()
        {
            Status = ScheduleStatus.Active;
            ModifiedAt = DateTime.UtcNow;
        }
        
        public void UpdateDetails(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}