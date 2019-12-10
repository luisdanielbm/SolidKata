using NSubstitute;
using System;
using Xunit;

namespace SolidKata._5.Dependency_Inversion
{
    public class UserRepositoryShould
    {
        [Fact]
        public void CreateUserWhenUserIsAInternalUser()
        {
            var dataBase = Substitute.For<IDatabase>();
            var logger = Substitute.For<Logger>();
            var userRepository = new UserRepository(dataBase);
            var user = new User(UserTypeDirectory.Internal);

            userRepository.CreateUser(user);

            dataBase.Received().Add(user);
            logger.Received().Success("");
        }

        [Fact]
        public void WriteErrorInLogWhenUserCanNotBeAdded()
        {
            var dataBase = Substitute.For<IDatabase>();
            var logger = Substitute.For<Logger>();
            var userRepository = new UserRepository(dataBase);
            var user = new User(UserTypeDirectory.Unknown);

            dataBase
                .When(substituteCall: db => db.Add(user))
                .Do(ex => throw new Exception());

            userRepository.CreateUser(user);

            logger.Received().Error("");
        }
    }
}
