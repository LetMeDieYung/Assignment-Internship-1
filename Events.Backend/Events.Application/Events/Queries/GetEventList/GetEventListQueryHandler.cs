using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Events.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
namespace Events.Application.Events.Quaries.GetEventList
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, EventListVm>
    {
        private readonly IEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IEventsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EventListVm> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var eventQuery = await _dbContext.Events
                .ProjectTo<EventLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new EventListVm { Events = eventQuery };
        }
    }
}
