using Events.Application.Interfaces;
using Events.Application.Common.Exceptions;
using Events.Domain;
using MediatR;

namespace Events.Application.Events.Commands.DeleteCommand
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand,Unit>
    {
        private readonly IEventsDbContext _dbContext;

        public DeleteEventCommandHandler(IEventsDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Events.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }
            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
