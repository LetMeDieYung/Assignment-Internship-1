using MediatR;

namespace Events.Application.Events.Commands.DeleteCommand
{
    public class DeleteEventCommand : IRequest, IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
