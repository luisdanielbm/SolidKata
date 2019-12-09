using System;
using NSubstitute;
using SolidKata._2._Open_Closed;
using Xunit;

namespace SolidKata._2
{
    public class UserServiceShould
    {
        [Fact]
        public void CreateUserWhenUserIsNotAGuest()
        {
            var userService = Substitute.For<IUserService>();
            var user = UserFactory.CreateUser(userService, UserTypeDirectory.Internal);

            user.CreateUser();

            userService.Received().Add();
        }

        [Fact]
        public void CreateUserAsGuestWhenUserIsAGuest()
        {
            var userService = Substitute.For<IUserService>();
            var guestUser = UserFactory.CreateUser(userService, UserTypeDirectory.Guest);

            guestUser.CreateUser();

            userService.Received().AddAsGuest();
        }

        [Fact]
        public void ThrowExceptionWhenUserCanNotBeAdded()
        {
            var userService = Substitute.For<IUserService>();
            var user = UserFactory.CreateUser(userService, UserTypeDirectory.Administrator);
            
            userService
                .When(substituteCall: db => db.Add())
                .Do(ex => throw new Exception());

            Assert.Throws<Exception>(() => user.CreateUser());
        }
    }
}
