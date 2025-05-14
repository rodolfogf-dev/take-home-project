using Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Serilog;
using System;
using THA.Application.Abstractions.Behaviors;
using THA.Application.Abstractions.Messaging;
using THA.Application.Persons.AddPerson;
using THA.Domain.Persons.Entities;
using THA.Domain.Persons.Repositories.Interfaces;
using THA.Fakes.Persons;
using THA.Fakes.Persons.Commands;

namespace THA.Application.Tests.Persons.Commands
{
    [TestFixture]
    internal class AddPersonCommandHandlerTest : TestBase
    {
        private ServiceCollection _services;
        private ServiceProvider _serviceProvider;
        private IPersonRepository _personRepository;
        private Guid _personIdDefault;

        [OneTimeSetUp]
        public void Setup()
        {
            _personIdDefault = Guid.NewGuid();
            _services = new ServiceCollection();
            _services.AddApplication();

            _personRepository = Substitute.For<IPersonRepository>();
            _personRepository.AddAsync(Arg.Any<Person>()).Returns(_personIdDefault);

            _services.Replace(new ServiceDescriptor(typeof(IPersonRepository), _ => _personRepository, ServiceLifetime.Scoped));
            _services.AddScoped(_ => Substitute.For<ILogger<LoggingDecorator.CommandHandler<AddPersonCommand, Guid>>>());
            _serviceProvider = _services.BuildServiceProvider();            
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await _serviceProvider.DisposeAsync();
        }

        [Test]
        public async Task Should_Add_Person_Returns_PersonId()
        {
            //Arrange
            using var scope = _serviceProvider.CreateScope();
            var addPersonCommandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<AddPersonCommand, Guid>>();
            var person = PersonFakes.GetPersonSample();

            //Act
            var result = await addPersonCommandHandler.Handle(AddPersonCommandFakes.GetAddPersonCommandSampleFake(), new CancellationToken());

            //Assert
            await _personRepository.Received(1).AddAsync(Arg.Any<Person>());
            Assert.That(result.Value, Is.EqualTo(_personIdDefault));
        }
    }
}
