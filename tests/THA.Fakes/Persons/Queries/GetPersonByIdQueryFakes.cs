using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THA.Application.Persons.AddPerson;
using THA.Application.Persons.GetById;

namespace THA.Fakes.Persons.Queries
{
    public class GetPersonByIdQueryFakes
    {
        public static GetPersonByIdQuery GetPersonByIdQueryFake()
            => new(Guid.NewGuid());
    }
}
