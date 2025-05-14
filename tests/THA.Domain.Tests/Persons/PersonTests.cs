using THA.Domain.Persons;
using THA.Domain.Persons.Entities;

namespace THA.Domain.Tests.Persons
{
    internal class PersonTests : TestBase
    {

        [Test]
        public void Should_Throw_Exception_When_PersonFullName_Is_Invalid()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Person(Guid.NewGuid(), null, Gender.Male, DateTime.Now, "Recife", null, null));
            Assert.That("Person Full Name must be specified", Is.EqualTo(exception.Message));
        }
    }
}
