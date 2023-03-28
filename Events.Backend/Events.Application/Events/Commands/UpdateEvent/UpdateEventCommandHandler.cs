using Events.Application.Common.Exceptions;
using MediatR;
using Events.Application.Interfaces;
using Events.Domain;
using Microsoft.EntityFrameworkCore;

namespace Events.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler
        : IRequestHandler<UpdateEventCommand, Unit>
    {
        private readonly IEventsDbContext _dbContext;

        public UpdateEventCommandHandler(IEventsDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Events.FirstOrDefaultAsync(newEvent => newEvent.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.ImageId = request.ImageId;
            entity.SpaceId = request.SpaceId;
            entity.StartDateTime = request.StartDateTime;
            entity.EndDateTime = request.EndDateTime;
            entity.Tickets = request.Tickets;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        
    }
}
