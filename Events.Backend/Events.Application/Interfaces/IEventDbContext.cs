using Microsoft.EntityFrameworkCore;
using Events.Domain;
namespace Events.Application.Interfaces
{
    public interface IEventsDbContext
    {
        DbSet<Event> Events { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
