using NSubstitute;
using System;
using Xunit;

namespace SolidKata._5.Dependency_Inversion
{
    public class UserRepositoryShould
    {
        [Fact]
        public void CreateUserWhenNoErrorWasThrow()
        {
            var dataBase = Substitute.For<IDatabase>();
            var logger = Substitute.For<Logger>();
            var userRepository = new UserRepository(dataBase);
            var user = new User("SOLID");

            userRepository.CreateUser(user);

            dataBase.Received().Add(user);
            logger.Received().Success("");
        }

        [Fact]
        public void CallLoggerWhenUserCanNotBeAdded()
        {
            var dataBase = Substitute.For<IDatabase>();
            var logger = Substitute.For<Logger>();
            var userRepository = new UserRepository(dataBase);
            var user = new User("SOLID");

            dataBase
                .When(substituteCall: db => db.Add(user))
                .Do(ex => throw new Exception());

            Assert.Throws<Exception>(() => userRepository.CreateUser(user));
            logger.Received().Error("");
        }
    }
}
