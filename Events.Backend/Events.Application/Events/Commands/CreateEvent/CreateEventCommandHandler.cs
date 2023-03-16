using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Events.Domain;
using Events.Application.Interfaces;
namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventsDbContext _dbContext;

        public CreateEventCommandHandler(IEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                ImageId = request.ImageId,
                SpaceId = request.SpaceId,
                StartDateTime = request.StartDateTime,
                EndDateTime = request.EndDateTime,
                Tickets = request.Tickets
    };

            await _dbContext.Events.AddAsync(newEvent, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newEvent.Id;
        }
    }
}
