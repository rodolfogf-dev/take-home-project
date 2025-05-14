using FluentValidation;

namespace THA.Application.Persons.RecordBirth
{
    public class RecordBirthCommandValidator : AbstractValidator<RecordBirthCommand>
    {
        public RecordBirthCommandValidator()
        {
            RuleFor(c => c.PersonId).NotEmpty();
            RuleFor(c => c.BirthDate).NotEmpty();
            RuleFor(c => c.BirthLocation).NotEmpty();
        }
    }
}
