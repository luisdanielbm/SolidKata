using NSubstitute;
using System;
using Xunit;

namespace SolidKata._3.Liskov_Substitution
{
    public class UserServiceShould
    {
        [Fact]
        public void CreateUserWhenUserNameIsNotGorA()
        {
            var userService = Substitute.For<IUserService>();
            var user = UserFactory.CreateUser("X", userService);

            user.CreateUser();

            userService.Received().Add();
        }

        [Fact]
        public void CreateUserAsGuestWhenUserNameIsG()
        {
            var userService = Substitute.For<IUserService>();
            var guestUser = UserFactory.CreateUser("G", userService);

            guestUser.CreateUser();

            userService.Received().AddAsGuest();
        }

        [Fact]
        public void CreateUserAsAdministratorWhenUserNameIsA()
        {
            var userService = Substitute.For<IUserService>();
            var administratorUser = UserFactory.CreateUser("A", userService);

            administratorUser.CreateUser();

            userService.Received().Add();
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
