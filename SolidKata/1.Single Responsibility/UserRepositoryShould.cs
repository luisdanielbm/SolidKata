using NSubstitute;
using System;
using Xunit;

namespace SolidKata._1.Single_Responsibility
{
    public class UserRepositoryShould
    {
        [Fact]
        public void CreateUserWhenUserIsNotAGuest()
        {
            var dataBase = Substitute.For<IDatabase>();
            var userRepository = new UserRepository(dataBase);
            var user = new User(UserTypeDirectory.Administrator);

            userRepository.CreateUser(user);

            dataBase.Received().Add(user);
        }

        [Fact]
        public void ThrowExceptionWhenUserIsGuest()
        {
            var dataBase = Substitute.For<IDatabase>();
            var userRepository = new UserRepository(dataBase);
            var user = new User(UserTypeDirectory.Guest);

            dataBase
                .When(substituteCall: db => db.Add(user))
                .Do(ex => throw new Exception());

            Assert.Throws<Exception>(() => userRepository.CreateUser(user));
        }
    }
}
