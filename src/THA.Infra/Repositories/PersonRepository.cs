using Microsoft.EntityFrameworkCore;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons.Repositories.Interfaces;
using THA.Infra.Database;


namespace THA.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ITakeHomeDbContext _Dbcontext;
        public PersonRepository(ITakeHomeDbContext dbcontext) 
        {
            _Dbcontext = dbcontext;
        }
        public async Task<IList<Person>> GetAllAsync()
            => await _Dbcontext.Persons.ToListAsync();
        public async Task<Person> GetByIdAsync(Guid personId)
            => await _Dbcontext.Persons.FirstOrDefaultAsync(x => x.Id == personId);
    }
}
