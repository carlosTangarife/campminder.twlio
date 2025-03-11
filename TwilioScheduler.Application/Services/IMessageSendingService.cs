using System.Threading.Tasks;
using TwilioScheduler.Domain.Entities;

namespace TwilioScheduler.Application.Services
{
    public interface IMessageSendingService
    {
        Task<string> SendSmsAsync(ScheduledMessage message);
        Task<string> MakeCallAsync(ScheduledMessage message);
    }
}