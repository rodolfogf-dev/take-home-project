using FluentValidation;

namespace THA.Application.Persons.AddPerson
{
    public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
    {
        public AddPersonCommandValidator()
        {
            RuleFor(c => c.PersonFullName).NotEmpty();
            RuleFor(c => c.Gender).IsInEnum();
            RuleFor(c => c.BirthDate).NotEmpty();
            RuleFor(c => c.BirthLocation).NotEmpty();
            RuleFor(c => c.DeathLocation).NotEmpty().When(x => x.DeathDate.HasValue);
        }
    }
}
