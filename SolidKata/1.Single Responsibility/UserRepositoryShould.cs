using System;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace SolidKata._1.Single_Responsibility
{
    public class UserRepositoryShould
    {
        [Fact]
        public void CreateUserWhenNoErrorWasThrow()
        {
            var dataBase = Substitute.For<IDatabase>();
            var userRepository = new UserRepository(dataBase);
            var user = new User("NoSOLID");

            userRepository.CreateUser(user);

            dataBase.Received().Add(user);
        }

        [Fact]
        public void ThrowExceptionWhenUserCanNotBeAdded()
        {
            var dataBase = Substitute.For<IDatabase>();
            var userRepository = new UserRepository(dataBase);
            var user = new User("SOLID");

            dataBase
                .When(substituteCall: db => db.Add(user))
                .Do(ex => throw new Exception());

            Assert.Throws<Exception>(() => userRepository.CreateUser(user));
        }
    }
}
