using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons.Repositories.Interfaces;
using THA.Infra.Database;


namespace THA.Infra.Repositories
{
    public class PersonRepository(ITakeHomeDbContext dbcontext) : IPersonRepository
    {
        private readonly ITakeHomeDbContext _Dbcontext = dbcontext;

        public async Task<List<Person>> GetAllAsync()
            => await _Dbcontext.Persons.Select(p => new Person()
            {
                Id = p.Id,
                BirthDate = p.BirthDate,
                BirthLocation = p.BirthLocation,
                DeathDate = p.DeathDate,
                DeathLocation = p.DeathLocation,
                PersonFullName = p.PersonFullName                
            }).ToListAsync();

        public async Task<Person> GetByIdAsync(Guid personId)
        {
            return await _Dbcontext.Persons.FirstOrDefaultAsync(x => x.Id == personId);
        }

        public async Task<Guid> AddAsync(Person person)
        {
            person.Id = Guid.NewGuid();
            await _Dbcontext.Persons.AddAsync(person);
            await _Dbcontext.SaveChangesAsync();
            return person.Id;
        }

        public async Task<Person> RecordBirth(Guid personId, DateTime birthDate, string birthLocation)
        {
            var person = _Dbcontext.Persons.FirstOrDefault(x => x.Id == personId);
            if (person is not null)
            {
                person.BirthDate = birthDate;
                person.BirthLocation = birthLocation;
            }          
            await _Dbcontext.SaveChangesAsync();
            return person;
        }
    }
}
