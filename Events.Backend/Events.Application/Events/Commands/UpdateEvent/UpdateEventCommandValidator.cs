using FluentValidation;

namespace Events.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(updateEventCommand => updateEventCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateEventCommand => updateEventCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}
