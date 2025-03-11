using TwilioScheduler.Domain.Entities;

namespace TwilioScheduler.Domain.Repositories
{
    public interface IScheduledMessageRepository
    {
        Task<ScheduledMessage> GetByIdAsync(Guid id);
        Task<IEnumerable<ScheduledMessage>> GetByScheduleIdAsync(Guid scheduleId);
        Task<IEnumerable<ScheduledMessage>> GetPendingMessagesAsync(DateTime before);
        Task AddAsync(ScheduledMessage message);
        Task UpdateAsync(ScheduledMessage message);
    }
}