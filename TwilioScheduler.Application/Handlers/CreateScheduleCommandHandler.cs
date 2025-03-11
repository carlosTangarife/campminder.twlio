using MediatR;
using TwilioScheduler.Application.Commands;
using TwilioScheduler.Domain.Entities;
using TwilioScheduler.Domain.Repositories;
using TwilioScheduler.Domain.ValueObjects;

namespace TwilioScheduler.Application.Handlers
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Guid>
    {
        private readonly IScheduleRepository _scheduleRepository;
        
        public CreateScheduleCommandHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        
        public async Task<Guid> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            RecurrencePattern recurrencePattern = null;
            
            if (request.RecurrencePattern != null)
            {
                switch (request.RecurrencePattern.Type)
                {
                    case "Daily":
                        recurrencePattern = RecurrencePattern.Daily(request.RecurrencePattern.Interval);
                        break;
                    case "Weekly":
                        var daysOfWeek = Array.ConvertAll(request.RecurrencePattern.DaysOfWeek, day => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day));
                        recurrencePattern = RecurrencePattern.Weekly(request.RecurrencePattern.Interval, daysOfWeek);
                        break;
                    case "Monthly":
                        recurrencePattern = RecurrencePattern.Monthly(request.RecurrencePattern.Interval, request.RecurrencePattern.DayOfMonth.Value);
                        break;
                    case "Yearly":
                        recurrencePattern = RecurrencePattern.Yearly(
                            request.RecurrencePattern.Interval, 
                            request.RecurrencePattern.MonthOfYear.Value, 
                            request.RecurrencePattern.DayOfMonth.Value);
                        break;
                }
            }
            
            var schedule = new Schedule(
                request.Name,
                request.Description,
                request.StartDate,
                recurrencePattern,
                request.EndDate
            );
            
            await _scheduleRepository.AddAsync(schedule);
            
            return schedule.Id;
        }
    }
}