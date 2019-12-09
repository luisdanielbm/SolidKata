using NSubstitute;
using System;
using Xunit;

namespace SolidKata._3.Liskov_Substitution
{
    public class UserServiceShould
    {
        [Fact]
        public void CreateUserWhenUserIsAInternalUser()
        {
            var userService = Substitute.For<IUserService>();
            var user = UserFactory.CreateUser(UserTypeDirectory.Internal, userService);

            user.CreateUser();

            userService.Received().Add();
        }

        [Fact]
        public void CreateUserAsGuestWhenUserIsAGuest()
        {
            var userService = Substitute.For<IUserService>();
            var guestUser = UserFactory.CreateUser(UserTypeDirectory.Guest, userService);

            guestUser.CreateUser();

            userService.Received().AddAsGuest();
        }

        [Fact]
        public void CreateUserAsAdministratorWhenUserIsAAdministrator()
        {
            var userService = Substitute.For<IUserService>();
            var administratorUser = UserFactory.CreateUser(UserTypeDirectory.Administrator, userService);

            administratorUser.CreateUser();

            userService.Received().Add();
        }

        [Fact]
        public void ThrowExceptionWhenUserCanNotBeAdded()
        {
            var userService = Substitute.For<IUserService>();
            var user = UserFactory.CreateUser(UserTypeDirectory.Unknown, userService);

            userService
                .When(substituteCall: db => db.Add())
                .Do(ex => throw new Exception());

            Assert.Throws<Exception>(() => user.CreateUser());
        }
    }
}
