namespace SolidKata._2._Open_Closed
{
    public static class UserFactory
    {
        public static User CreateUser(IUserService userService, UserTypeDirectory userType)
        {
            return new User(userService, userType);
        }
    }
}
