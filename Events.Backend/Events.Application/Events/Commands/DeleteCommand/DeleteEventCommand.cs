using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Events.Application.Events.Commands.DeleteCommand
{
    public class DeleteEventCommand : IRequest, IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
