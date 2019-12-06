using System;
using NSubstitute;
using SolidKata._2._Open_Closed;
using Xunit;

namespace SolidKata._2
{
    public class UserRepositoryShould
    {
        [Fact]
        public void CreateUserWhenUserNameIsNotX()
        {
            var userRepository = Substitute.For<IUserRepository>();
            var user = UserFactory.CreateUser("Y", userRepository);

            user.CreateUser();

            userRepository.Received().Add();
        }

        [Fact]
        public void CreateUserAsGuestWhenUserNameIsX()
        {
            var userRepository = Substitute.For<IUserRepository>();
            var guestUser = UserFactory.CreateUser("X", userRepository);

            guestUser.CreateUser();

            userRepository.Received().AddAsGuest();
        }

        [Fact]
        public void ThrowExceptionWhenUserCanNotBeAdded()
        {
            var userRepository = Substitute.For<IUserRepository>();
            var user = UserFactory.CreateUser("SOLID", userRepository);
            
            userRepository
                .When(substituteCall: db => db.Add())
                .Do(ex => throw new Exception());

            Assert.Throws<Exception>(() => user.CreateUser());
        }
    }
}
