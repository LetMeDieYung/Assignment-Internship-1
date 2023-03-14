using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
