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
        }
    }
}
