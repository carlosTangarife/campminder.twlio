using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TwilioScheduler.Application.DTOs;
using TwilioScheduler.Application.Queries;
using TwilioScheduler.Domain.Repositories;

namespace TwilioScheduler.Application.Handlers
{
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, ScheduleDto>
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;
        
        public GetScheduleByIdQueryHandler(
            IScheduleRepository scheduleRepository,
            IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }
        
        public async Task<ScheduleDto> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(request.Id);
            
            if (schedule == null)
            {
                return null;
            }
            
            return _mapper.Map<ScheduleDto>(schedule);
        }
    }
}