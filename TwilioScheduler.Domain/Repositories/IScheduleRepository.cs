using TwilioScheduler.Domain.Entities;

namespace TwilioScheduler.Domain.Repositories
{
    public interface IScheduleRepository
    {
        Task<Schedule> GetByIdAsync(Guid id);
        Task<IEnumerable<Schedule>> GetAllAsync();
        Task<IEnumerable<Schedule>> GetActiveSchedulesAsync();
        Task AddAsync(Schedule schedule);
        Task UpdateAsync(Schedule schedule);
        Task<bool> ExistsAsync(Guid id);
    }
}