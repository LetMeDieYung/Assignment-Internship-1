using MediatR;

namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid ImageId { get; set; }
        public Guid SpaceId { get; set; }
        public int Tickets { get; set; }
    }
}
