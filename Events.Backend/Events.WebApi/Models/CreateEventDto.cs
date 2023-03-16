using System.Diagnostics.Tracing;
using AutoMapper;
using Events.Application.Common.Mappings;
using Events.Application.Events.Commands.CreateEvent;
using System.ComponentModel.DataAnnotations;
namespace Events.WebApi.Models
{
    public class CreateEventDto : IMapWith<CreateEventCommand>
    {
        [Required]
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ImageId { get; set; }
        public Guid SpaceId { get; set; }
        public int Tickets { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEventDto, CreateEventCommand>()
                .ForMember(eventCommand => eventCommand.Title, opt => opt.MapFrom(eventDto => eventDto.Title))
                .ForMember(eventCommand => eventCommand.Description,
                    opt => opt.MapFrom(eventDto => eventDto.Description))
                .ForMember(eventCommand => eventCommand.StartDateTime,
                    opt => opt.MapFrom(eventDto => eventDto.StartDateTime))
                .ForMember(eventCommand => eventCommand.EndDateTime,
                    opt => opt.MapFrom(eventDto => eventDto.EndDateTime))
                .ForMember(eventCommand => eventCommand.ImageId, opt => opt.MapFrom(eventDto => eventDto.ImageId))
                .ForMember(eventCommand => eventCommand.SpaceId, opt => opt.MapFrom(eventDto => eventDto.SpaceId))
                .ForMember(eventCommand => eventCommand.Tickets, opt => opt.MapFrom(eventDto => eventDto.Tickets));

        }
    }
}
