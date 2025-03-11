using MediatR;
using TwilioScheduler.Application.Commands;
using TwilioScheduler.Domain.Entities;
using TwilioScheduler.Domain.Repositories;

namespace TwilioScheduler.Application.Handlers
{
    public class AddScheduledMessageCommandHandler : IRequestHandler<AddScheduledMessageCommand, Guid>
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IScheduledMessageRepository _messageRepository;
        
        public AddScheduledMessageCommandHandler(
            IScheduleRepository scheduleRepository,
            IScheduledMessageRepository messageRepository)
        {
            _scheduleRepository = scheduleRepository;
            _messageRepository = messageRepository;
        }
        
        public async Task<Guid> Handle(AddScheduledMessageCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(request.ScheduleId);
            
            if (schedule == null)
            {
                throw new ApplicationException($"Schedule with id {request.ScheduleId} not found");
            }
            
            var message = new ScheduledMessage(
                request.ScheduleId,
                request.RecipientPhoneNumber,
                request.Content,
                request.Type,
                request.ScheduledTime
            );
            
            schedule.AddMessage(message);
            await _scheduleRepository.UpdateAsync(schedule);
            
            return message.Id;
        }
    }
}