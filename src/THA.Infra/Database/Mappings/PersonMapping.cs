using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons;

namespace THA.Infra.Database.Mappings
{
    internal class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(t => t.Id);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.BirthLocation).IsRequired();
            builder.Property(x => x.DeathLocation).IsRequired(false);
            builder.Property(x => x.DeathDate).IsRequired(false);
            builder
                .OwnsOne(x => x.PersonFullName)
                .Property(x => x.GivenName)
                .HasColumnName("Email")
                .IsRequired(true);
            builder
                .OwnsOne(x => x.PersonFullName)
                .Property(x => x.Surname)
                .HasColumnName("Surname")
                .IsRequired(true);

            builder.HasData(
                new Person()
                {
                    Id = Guid.NewGuid(),
                    PersonFullName = new PersonFullName("Rodolfo", "Gomes"),
                    BirthDate = DateTime.Now,
                    BirthLocation = "Recife",
                    Gender = Gender.Male
                });
        }
    }
}
