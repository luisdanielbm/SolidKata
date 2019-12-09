namespace SolidKata._5.Dependency_Inversion
{
    public class User
    {
        private readonly UserTypeDirectory _userType;

        public User(UserTypeDirectory userType)
        {
            _userType = userType;
        }

        public UserTypeDirectory GetUserType()
        {
            return _userType;
        }
    }
}
