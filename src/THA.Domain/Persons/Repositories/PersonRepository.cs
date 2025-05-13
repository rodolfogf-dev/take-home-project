using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons.Repositories.Interfaces;

namespace THA.Domain.Persons.Repositories
{
    public class PersonRepository : IPersonRepository
    {
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
