using TwilioScheduler.Domain.Enums;

namespace TwilioScheduler.Application.DTOs
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public ScheduleStatus Status { get; set; }
        public RecurrencePatternDto RecurrencePattern { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<ScheduledMessageDto> Messages { get; set; }
    }
}