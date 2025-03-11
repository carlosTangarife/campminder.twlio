using MediatR;
using TwilioScheduler.Domain.Enums;

namespace TwilioScheduler.Application.Commands
{
    public class AddScheduledMessageCommand : IRequest<Guid>
    {
        public Guid ScheduleId { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string Content { get; set; }
        public MessageType Type { get; set; }
        public DateTime ScheduledTime { get; set; }
    }
}