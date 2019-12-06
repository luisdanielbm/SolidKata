namespace SolidKata._3.Liskov_Substitution
{
    public static class UserFactory
    {
        public static User CreateUser(string userName, IUserService userService)
        {
            if (userName == "G")
            {
                return new GuestUser(userName, userService);
            }

            if (userName == "A")
            {
                return new AdministratorUser(userName, userService);
            }

            return new User(userName, userService);
        }
    }
}
