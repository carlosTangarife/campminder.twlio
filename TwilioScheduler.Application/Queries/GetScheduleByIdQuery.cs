using MediatR;
using TwilioScheduler.Application.DTOs;

namespace TwilioScheduler.Application.Queries
{
    public class GetScheduleByIdQuery : IRequest<ScheduleDto>
    {
        public Guid Id { get; set; }
        
        public GetScheduleByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}