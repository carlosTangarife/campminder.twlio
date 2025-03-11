namespace TwilioScheduler.Domain.Entities
{
    public class MessageResponse
    {
        public Guid Id { get; private set; }
        public Guid ScheduledMessageId { get; private set; }
        public string ResponseContent { get; private set; }
        public string FromPhoneNumber { get; private set; }
        public DateTime ReceivedAt { get; private set; }
        
        // For EF
        private MessageResponse() {}
        
        public MessageResponse(
            Guid scheduledMessageId,
            string responseContent,
            string fromPhoneNumber)
        {
            Id = Guid.NewGuid();
            ScheduledMessageId = scheduledMessageId;
            ResponseContent = responseContent;
            FromPhoneNumber = fromPhoneNumber;
            ReceivedAt = DateTime.UtcNow;
        }
    }
}