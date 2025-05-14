using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using THA.Application.Abstractions.Messaging;
using THA.Domain.Persons.Repositories.Interfaces;
using THA.Fakes.Persons;
using Microsoft.Extensions.DependencyInjection.Extensions;
using THA.Application.Abstractions.Behaviors;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using THA.Application.Persons;
using THA.Application.Persons.GetById;
using THA.Fakes.Persons.Queries;

namespace THA.Application.Tests.Persons.Queries
{
    internal class GetPersonByIdQueryHandlerTest
    {
        private ServiceCollection _services;
        private ServiceProvider _serviceProvider;
        private IPersonRepository _personRepository;
        private Guid _personIdDefault;

        [OneTimeSetUp]
        public void Setup()
        {
            _personIdDefault = Guid.NewGuid();
            _services = [];
            _services.AddApplication();

            _personRepository = Substitute.For<IPersonRepository>();
            _personRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(PersonFakes.GetPersonSample());

            _services.Replace(new ServiceDescriptor(typeof(IPersonRepository), _ => _personRepository, ServiceLifetime.Scoped));
            _services.AddScoped(_ => Substitute.For<ILogger<LoggingDecorator.QueryHandler<GetPersonByIdQuery, PersonResponse>>>());
            _serviceProvider = _services.BuildServiceProvider();
        }

        [OneTimeTearDown]
        public async Task TearDown()
            => await _serviceProvider.DisposeAsync();

        [Test]
        public async Task Should_Get_Person_By_PersonId()
        {
            //Arrange
            using var scope = _serviceProvider.CreateScope();
            var getPersonByIdHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPersonByIdQuery, PersonResponse>>();
            var person = PersonResponseFakes.GetPersonResponseSample();

            //Act
            var result = await getPersonByIdHandler.Handle(GetPersonByIdQueryFakes.GetPersonByIdQueryFake(), new CancellationToken());

            //Assert
            await _personRepository.Received(1).GetByIdAsync(Arg.Any<Guid>());
            result.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(person);
        }

        //.
        //.
        //.
        //[Test]
        //public async Task Should_Throw_.....()
    }
}
