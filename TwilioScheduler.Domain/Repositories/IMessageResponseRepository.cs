using TwilioScheduler.Domain.Entities;

namespace TwilioScheduler.Domain.Repositories
{
    public interface IMessageResponseRepository
    {
        Task<MessageResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<MessageResponse>> GetByScheduledMessageIdAsync(Guid scheduledMessageId);
        Task AddAsync(MessageResponse response);
    }
}