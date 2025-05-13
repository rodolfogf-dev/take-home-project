using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons.Repositories.Interfaces;
using THA.Infra.Database;


namespace THA.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository(ITakeHomeDbContext dbcontext) 
        {
            dbcontext
        }
        public IList<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person GetById()
        {
            throw new NotImplementedException();
        }
    }
}
