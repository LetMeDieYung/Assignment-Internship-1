using FluentValidation;

namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(createEventCommand => createEventCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createEventCommand => createEventCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
