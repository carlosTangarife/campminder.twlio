using TwilioScheduler.Domain.Enums;

namespace TwilioScheduler.Application.DTOs;

public class ScheduledMessageDto
{
    public Guid Id { get; set; }
    public Guid ScheduleId { get; set; }
    public string RecipientPhoneNumber { get; set; }
    public string Content { get; set; }
    public MessageType Type { get; set; }
    public MessageStatus Status { get; set; }
    public DateTime ScheduledTime { get; set; }
    public DateTime? SentTime { get; set; }
    public string TwilioMessageId { get; set; }
}