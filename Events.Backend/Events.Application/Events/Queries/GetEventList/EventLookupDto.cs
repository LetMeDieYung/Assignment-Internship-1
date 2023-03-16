using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Application.Common.Mappings;
using MediatR;
using Events.Domain;

namespace Events.Application.Events.Quaries.GetEventList
{
    public class EventLookupDto : IMapWith<Event>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid ImageId { get; set; }
        public Guid SpaceId { get; set; }
        public int Tickets { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventLookupDto>()
                .ForMember(eventDto => eventDto.Id, opt => opt.MapFrom(newEvent => newEvent.Id))
                .ForMember(eventDto => eventDto.Title, opt => opt.MapFrom(newEvent => newEvent.Title))
                .ForMember(eventDto => eventDto.Description, opt => opt.MapFrom(newEvent => newEvent.Description))
                .ForMember(eventDto => eventDto.StartDateTime, opt => opt.MapFrom(newEvent => newEvent.StartDateTime))
                .ForMember(eventDto => eventDto.EndDateTime, opt => opt.MapFrom(newEvent => newEvent.EndDateTime))
                .ForMember(eventDto => eventDto.ImageId, opt => opt.MapFrom(newEvent => newEvent.ImageId))
                .ForMember(eventDto => eventDto.SpaceId, opt => opt.MapFrom(newEvent => newEvent.SpaceId))
                .ForMember(eventDto => eventDto.Tickets, opt => opt.MapFrom(newEvent => newEvent.Tickets));
        }
    }
}
