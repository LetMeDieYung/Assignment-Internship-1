using AutoMapper;
using Events.Application.Common.Mappings;
using Events.Application.Events.Commands.UpdateEvent;
using Microsoft.EntityFrameworkCore;

namespace Events.WebApi.Models
{
    public class UpdateEventDto : IMapWith<UpdateEventCommand>
    {
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid ImageId { get; set; }
        public Guid SpaceId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEventDto,UpdateEventCommand>()
                .ForMember(eventCommand => eventCommand.Title, opt => opt.MapFrom(eventDto => eventDto.Title))
                .ForMember(eventCommand => eventCommand.Description,
                    opt => opt.MapFrom(eventDto => eventDto.Description))
                .ForMember(eventCommand => eventCommand.StartDateTime,
                    opt => opt.MapFrom(eventDto => eventDto.StartDateTime))
                .ForMember(eventCommand => eventCommand.EndDateTime,
                    opt => opt.MapFrom(eventDto => eventDto.EndDateTime))
                .ForMember(eventCommand => eventCommand.ImageId, opt => opt.MapFrom(eventDto => eventDto.ImageId))
                .ForMember(eventCommand => eventCommand.SpaceId, opt => opt.MapFrom(eventDto => eventDto.SpaceId));


        }
    }
}
