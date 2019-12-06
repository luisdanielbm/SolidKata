namespace SolidKata._2._Open_Closed
{
    public static class UserFactory
    {
        public static User CreateUser(string userName, IUserRepository userRepository)
        {
            return new User(userName, userRepository);
        }
    }
}
