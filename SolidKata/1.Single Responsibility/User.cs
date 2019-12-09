namespace SolidKata._1.Single_Responsibility
{
    public class User
    {
        private readonly UserTypeDirectory _type;

        public User(UserTypeDirectory type)
        {
            _type = type;
        }

        public UserTypeDirectory GetUserType()
        {
            return _type;
        }
    }
}