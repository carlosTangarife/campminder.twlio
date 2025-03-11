using Microsoft.EntityFrameworkCore;
using TwilioScheduler.Domain.Entities;
using TwilioScheduler.Domain.Enums;
using TwilioScheduler.Domain.Repositories;
using TwilioScheduler.Infrastructure.Persistence;

namespace TwilioScheduler.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDbContext _context;
        
        public ScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Schedule> GetByIdAsync(Guid id)
        {
            return await _context.Schedules
                .Include(s => s.Messages)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        
        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
            return await _context.Schedules
                .Include(s => s.Messages)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Schedule>> GetActiveSchedulesAsync()
        {
            return await _context.Schedules
                .Include(s => s.Messages)
                .Where(s => s.Status == ScheduleStatus.Active)
                .ToListAsync();
        }
        
        public async Task AddAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }
        
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Schedules.AnyAsync(s => s.Id == id);
        }
    }
}