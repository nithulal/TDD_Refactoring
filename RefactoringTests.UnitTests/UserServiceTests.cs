using LegacyApp;
using LegacyApp.Services;
using LegacyApp.Repositories;
using LegacyApp.Models;
using LegacyApp.DataAccess;
using NSubstitute;
using System;
using Xunit;
using AutoFixture;
using FluentAssertions;
using LegacyApp.Validators;
using LegacyApp.CreditProviders;

namespace RefactoringTests.UnitTests
{
    public class UserServiceTests
    {
        private readonly UserService _sut;
        private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        private readonly IClientRepository _clientRepository = Substitute.For<IClientRepository>();
        private readonly IUserDataAccess _userDataAccess = Substitute.For<IUserDataAccess>();
        private readonly IUserCreditService _userCreditService = Substitute.For<IUserCreditService>();
        private readonly CreditLimitProviderFactory _creditLimitProviderFactory = Substitute.For<CreditLimitProviderFactory>();
        private readonly IFixture _fixture = new Fixture();

        public UserServiceTests()
        {
            _sut = new UserService(_clientRepository,_userDataAccess,new UserValidator(_dateTimeProvider),new CreditLimitProviderFactory(_userCreditService));
        }
        [Fact]
        public void AddUser_ShouldCreateUser_WhenAllParametersAreValid()
        {

            //Arrange
            const int clientId = 1;
            const string firstName = "";
            const string lastName = "";
            var dateOfBirth = new DateTime(1991,09,20);
            var client = _fixture.Build<Client>()
                .With(c => c.Id , clientId)
                .Create();
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2001, 03, 11));
            _clientRepository.GetById(clientId).Returns(client);
            _userCreditService.GetCreditLimit(firstName, lastName, dateOfBirth).Returns(600);

            //Act

            var result = _sut.AddUser(firstName,lastName,"test@gmail.com", dateOfBirth,clientId);

            //Assert
            result.Should().BeTrue();
        }
    }
}
