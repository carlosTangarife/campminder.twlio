using AutoMapper;
using TwilioScheduler.Application.DTOs;
using TwilioScheduler.Domain.Entities;
using TwilioScheduler.Domain.ValueObjects;

namespace TwilioScheduler.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Schedule, ScheduleDto>()
                .ForMember(dest => dest.RecurrencePattern, opt => opt.MapFrom(src => src.RecurrencePattern));
                
            CreateMap<RecurrencePattern, RecurrencePatternDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.DaysOfWeek, opt => opt.MapFrom(src => 
                    src.DaysOfWeek != null 
                        ? Array.ConvertAll(src.DaysOfWeek, day => day.ToString()) 
                        : null));
                
            CreateMap<ScheduledMessage, ScheduledMessageDto>();
            CreateMap<MessageResponse, MessageResponseDto>();
        }
    }
}