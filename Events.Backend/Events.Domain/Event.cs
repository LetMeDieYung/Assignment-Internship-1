using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain
{
    public class Event
    {
        public Guid Id { get; set; } 
        public DateTime StartDateTime { get; set; } 
        public DateTime EndDateTime { get; set; } 
        public string? Title { get; set; } 
        public string? Description { get; set; }
        public Guid ImageId { get; set; } 
        public Guid SpaceId { get; set; }
    }
}
