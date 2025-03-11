using System;
using System.Threading.Tasks;
using TwilioScheduler.Domain.Entities;

namespace TwilioScheduler.Application.Services
{
    public interface IMessageSchedulingService
    {
        Task ScheduleMessageAsync(ScheduledMessage message);
        Task CancelScheduledMessageAsync(Guid messageId);
    }
}