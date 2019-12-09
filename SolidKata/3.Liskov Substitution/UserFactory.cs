namespace SolidKata._3.Liskov_Substitution
{
    public static class UserFactory
    {
        public static User CreateUser(UserTypeDirectory userType, IUserService userService)
        {
            if (userType == UserTypeDirectory.Guest)
            {
                return new GuestUser(userService, userType);
            }

            if (userType == UserTypeDirectory.Administrator)
            {
                return new AdministratorUser(userService, userType);
            }

            return new User(userService, userType);
        }
    }
}
