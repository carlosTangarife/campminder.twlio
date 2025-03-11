using MediatR;
using TwilioScheduler.Application.DTOs;

namespace TwilioScheduler.Application.Commands
{
    public class CreateScheduleCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public RecurrencePatternDto RecurrencePattern { get; set; }
    }
}