using FluentValidation;

namespace Events.Application.Events.Commands.DeleteCommand
{
    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(deleteEventCommand => deleteEventCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
