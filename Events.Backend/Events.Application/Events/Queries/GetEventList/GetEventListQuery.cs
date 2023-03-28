using MediatR;

namespace Events.Application.Events.Quaries.GetEventList
{
    public class GetEventListQuery : IRequest<EventListVm>
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public Guid SpaceId { get; set; }
    }
}
