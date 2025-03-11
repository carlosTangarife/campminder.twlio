using System;
using TwilioScheduler.Domain.Enums;

namespace TwilioScheduler.Domain.Entities
{
    public class ScheduledMessage
    {
        public Guid Id { get; private set; }
        public Guid ScheduleId { get; private set; }
        public string RecipientPhoneNumber { get; private set; }
        public string Content { get; private set; }
        public MessageType Type { get; private set; }
        public MessageStatus Status { get; private set; }
        public DateTime ScheduledTime { get; private set; }
        public DateTime? SentTime { get; private set; }
        public string TwilioMessageId { get; private set; }
        
        // For EF
        private ScheduledMessage() {}
        
        public ScheduledMessage(
            Guid scheduleId,
            string recipientPhoneNumber,
            string content,
            MessageType type,
            DateTime scheduledTime)
        {
            Id = Guid.NewGuid();
            ScheduleId = scheduleId;
            RecipientPhoneNumber = recipientPhoneNumber ?? throw new ArgumentNullException(nameof(recipientPhoneNumber));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Type = type;
            Status = MessageStatus.Scheduled;
            ScheduledTime = scheduledTime;
        }
        
        public void MarkAsProcessing()
        {
            Status = MessageStatus.Processing;
        }
        
        public void MarkAsSent(string twilioMessageId)
        {
            Status = MessageStatus.Sent;
            SentTime = DateTime.UtcNow;
            TwilioMessageId = twilioMessageId;
        }
        
        public void MarkAsFailed()
        {
            Status = MessageStatus.Failed;
        }
    }
}