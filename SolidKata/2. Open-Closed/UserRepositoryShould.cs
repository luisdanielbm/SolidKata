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
            var userService = Substitute.For<IUserService>();
            var user = UserFactory.CreateUser("Y", userService);

            user.CreateUser();

            userService.Received().Add();
        }

        [Fact]
        public void CreateUserAsGuestWhenUserNameIsX()
        {
            var userService = Substitute.For<IUserService>();
            var guestUser = UserFactory.CreateUser("X", userService);

            guestUser.CreateUser();

            userService.Received().AddAsGuest();
        }

        [Fact]
        public void ThrowExceptionWhenUserCanNotBeAdded()
        {
            var userService = Substitute.For<IUserService>();
            var user = UserFactory.CreateUser("SOLID", userService);
            
            userService
                .When(substituteCall: db => db.Add())
                .Do(ex => throw new Exception());

            Assert.Throws<Exception>(() => user.CreateUser());
        }
    }
}
