namespace TwilioScheduler.Domain.Enums
{
    public enum MessageStatus
    {
        Scheduled,
        Processing,
        Sent,
        Delivered,
        Failed,
        Canceled
    }
}