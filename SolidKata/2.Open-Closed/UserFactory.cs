namespace SolidKata._2
{
    public static class UserFactory
    {
        public static User CreateUser(IUserService userService, UserTypeDirectory userType)
        {
            return new User(userService, userType);
        }
    }
}
