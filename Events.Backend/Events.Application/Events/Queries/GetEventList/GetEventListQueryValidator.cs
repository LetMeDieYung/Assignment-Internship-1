using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Application.Events.Quaries.GetEventList;
using FluentValidation;

namespace Events.Application.Events.Queries.GetEventList
{
    public class GetEventListQueryValidator : AbstractValidator<GetEventListQuery>
    {
        public GetEventListQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.ImageId).NotEqual(Guid.Empty);
            RuleFor(x => x.SpaceId).NotEqual(Guid.Empty);
        }
    }
}
