using System;
using NSubstitute;
using SolidKata._2._Open_Closed;
using Xunit;

namespace SolidKata._2
{
    public class UserRepositoryShould
    {
        [Fact]
        public void CreateUserWhenUserNameIsX()
        {
            var dataBase = Substitute.For<IDatabase>();
            var userRepository = new UserRepository(dataBase);
            var user = new User("X");

            userRepository.CreateUser(user);

            dataBase.Received().Add(user);
        }

        [Fact]
        public void CreateUserAsGuestWhenUserNameIsNotX()
        {
            var dataBase = Substitute.For<IDatabase>();
            var userRepository = new UserRepository(dataBase);
            var user = new User("Y");

            userRepository.CreateUser(user);

            dataBase.Received().AddAsGuest(user);
        }

        [Fact]
        public void ThrowExceptionWhenUserCanNotBeAdded()
        {
            var dataBase = Substitute.For<_1.Single_Responsibility.IDatabase>();
            var userRepository = new _1.Single_Responsibility.UserRepository(dataBase);
            var user = new _1.Single_Responsibility.User("SOLID");

            dataBase
                .When(substituteCall: db => db.Add(user))
                .Do(ex => throw new Exception());

            Assert.Throws<Exception>(() => userRepository.CreateUser(user));
        }
    }
}
