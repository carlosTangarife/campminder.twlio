using System.Collections.Generic;
using MediatR;
using TwilioScheduler.Application.DTOs;

namespace TwilioScheduler.Application.Queries
{
    public class GetActiveSchedulesQuery : IRequest<IEnumerable<ScheduleDto>>
    {
    }
}