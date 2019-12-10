namespace SolidKata._2
{
    public static class UserFactory
    {
        public static User CreateUser(IUserService userService, UserTypeDirectory userType)
        {
            if (userType == UserTypeDirectory.Guest)
            {
                return new GuestUser(userService, userType);
            }

            return new User(userService, userType);
        }
    }
}
